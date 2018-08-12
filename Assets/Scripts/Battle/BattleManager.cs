using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Threading.Tasks;
using System.Linq;
using UnityEngine.SceneManagement;
using Google2u;
using DarkTonic.MasterAudio;

namespace CCG
{
    public enum BattleState
    {
        Player,
        EnemySelected,
        Enemy,
    }

    public class BattleManager
    {
        #region inner classes
        public class BattleSetting
        {
            public Player Player { get; private set; }
            public List<Enemy> Enemies { get; private set; }

            public string Background { get; private set; }

            // 開始時シーンデータ
            public string StartSceneName { get; private set; } = "None";
            public Vector2 StartPosition { get; private set; }

            public BattleSetting(Player player, List<Enemy> enemies, string background
                                  , string startSceneName, Vector2 startPosition)
            {
                this.Player = player;
                this.Enemies = enemies;
                this.Background = background;

                this.StartSceneName = startSceneName;
                this.StartPosition = startPosition;
            }
        }
        #endregion

        #region properties
        public Player Player { get { return setting.Player; } }
        public List<Enemy> Enemies { get { return setting.Enemies; } }
        public string Background { get { return setting.Background; } }

        public BattleState State { get; private set; }
        public bool IsPlayerTurn { get { return State == BattleState.Player; } }
        public bool IsEnemyTurn { get { return State == BattleState.Enemy; } }

        public ExpTable ExpTable { get; private set; }

        public string StartScene { get { return setting.StartSceneName; } }
        public Vector2 StartPosition { get { return setting.StartPosition; } }

        private BattleSetting setting;
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BattleManager()
        {
            Init();
        }

        public static BattleManager Create()
        {
            return new BattleManager();
        }

        public void StartBattle(BattleSetting setting)
        {
            this.setting = setting;
            SceneManager.LoadScene("Battle");
        }

        public void PrepareBattle()
        {
            OnStartPlayerTurn();
        }

        /// <summary>
        /// 敵キャラクター選択時
        /// 自分のターン時のみ実行出来る
        /// </summary>
        public IEnumerator OnSelectEnemy(BattleEnemyController enemy)
        {
            if (!IsPlayerTurn)
                yield break;

            ChangeState(BattleState.EnemySelected);

            Player.Attack(enemy.Enemy);
            BattleUIManager.I.StatusPanel.Move(false);

            yield return WaitInterval();
            yield return enemy.PlayDamageEffect();

            // Playerターン終了
            yield return OnEndPlayerTurn();
        }
        #endregion

        #region private methods
        /// <summary>
        /// バトルの終了
        /// </summary>
        private IEnumerator FinishBattle(bool isWin)
        {
            if (isWin)
            {
                yield return OnWinBattle();
            }
            else
            {
                yield return OnLoseBattle();
            }

            OnEndFinishBattle();
        }

        /// <summary>
        /// 勝利時
        /// </summary>
        private IEnumerator OnWinBattle()
        {
            MasterAudio.FadeOutAllOfSound("Battle_001", 0.2f);
            MasterAudio.PlaySound("Jingle_001");

            // 勝利・敗北メッセージ
            int gainExpAmount = Enemies.Select(enemy => enemy.Status.Exp)
                           .Sum();
            var message = BattleLog.GetBattleWinMessage(Player.CharaName, gainExpAmount);
            yield return BattleUIManager.I.BattleLog.SetMessageCoroutine(message);

            yield return GainExp(gainExpAmount);
            yield return CheckDropItem();
        }

        /// <summary>
        /// 敗北時
        /// </summary>
        private IEnumerator OnLoseBattle()
        {
            // 敗北時はHPを1にしておく
            Player.Status.Health = 1;

            MasterAudio.FadeOutAllOfSound("Battle_001", 0.2f);
            MasterAudio.PlaySound("Jingle_001");

            // 勝利・敗北メッセージ
            int gainExpAmount = Enemies.Select(enemy => enemy.Status.Exp)
                           .Sum();
            var message = BattleLog.GetBattleLoseMessage(Player.CharaName);
            yield return BattleUIManager.I.BattleLog.SetMessageCoroutine(message);
        }

        private void OnEndFinishBattle()
        {
            // 終了時点のプレイヤーステータスを反映
            Global.Player.UpdateStatus(Player.Status);

            // プレイヤーデータをセーブ
            Global.SaveDataManager.Save();

            Release();

            // 開始前に居たシーンに戻す
            // 未設定の場合は、とりあえずMainシーンに戻す
            SceneManager.LoadScene(StartScene != "None" ? StartScene : "Main");
        }

        private IEnumerator GainExp(int gainExpAmount)
        {
            var isLevelup = Player.GainExp(gainExpAmount);

            if (isLevelup)
            {
                yield return Player.LevelUp();
                yield return GainExp(0);// レベルアップしなくなるまで再帰的に呼び出す
            }
        }

        private IEnumerator CheckDropItem()
        {
            foreach (Enemy enemy in Enemies)
            {
                if (!enemy.IsEmpty)
                {
                    float random = UnityEngine.Random.Range(0f, 100f);
                    if (random <= enemy.DropItem.DropRate)
                    {
                        // ドロップした
                        Global.Inventory.AddItem(enemy.DropItem.Item);

                        var message = BattleLog.GetDropItemMessage(enemy.CharaName, enemy.DropItem.Item.Name);
                        yield return BattleUIManager.I.BattleLog.SetMessageCoroutine(message);
                    }
                }
            }
        }

        private IEnumerator StartEnemiesTurn()
        {
            ChangeState(BattleState.Enemy);

            var attackers = Enemies
                .Where(enemy => !enemy.IsEmpty && !enemy.IsDead)
                .ToList();

            foreach (var enemy in attackers)
            {
                if (CheckPlayerDead())
                    break;

                enemy.Attack(Player);
                MasterAudio.PlaySound("EnemyHit");

                yield return WaitInterval();
            }

            // Enemyターン終了
            yield return OnEndEnemyTurn();
        }

        /// <summary>
        /// プレイヤーターン開始時
        /// </summary>
        private void OnStartPlayerTurn()
        {
            ChangeState(BattleState.Player);
            BattleUIManager.I.StatusPanel.Move(true);
        }

        /// <summary>
        /// プレイヤーターン終了時
        /// </summary>
        private IEnumerator OnEndPlayerTurn()
        {
            if (CheckEnemiesDead())
            {
                yield return FinishBattle(true);
            }
            else
            {
                yield return WaitInterval();
                yield return StartEnemiesTurn();
            }
        }

        private IEnumerator OnEndEnemyTurn()
        {
            if (CheckPlayerDead())
            {
                yield return FinishBattle(false);
            }
            else
            {
                OnStartPlayerTurn();
            }
        }

        private IEnumerator WaitInterval()
        {
            var wait = new WaitForSeconds(1);
            yield return wait;
        }

        private bool CheckPlayerDead()
        {
            return Player.IsDead;
        }

        private bool CheckEnemiesDead()
        {
            return Enemies.All(enemy => enemy.IsDead || enemy.IsEmpty);
        }

        private void ChangeState(BattleState next)
        {
            State = next;
        }

        private void Init()
        {
            ExpTable = new ExpTable();
        }

        private void Release()
        {
            ExpTable = null;
        }
        #endregion
    }
}