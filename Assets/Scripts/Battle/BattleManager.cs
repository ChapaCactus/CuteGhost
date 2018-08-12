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
            public List<IFightable> Enemies { get; private set; }

            public string Background { get; private set; }

            // 開始時シーンデータ
            public string StartSceneName { get; private set; } = "None";
            public Vector2 StartPosition { get; private set; }

            public BattleSetting(Player player, List<IFightable> enemies, string background
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
        public List<IFightable> Enemies { get { return setting.Enemies; } }
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
            
            State = BattleState.EnemySelected;

            Player.Attack(enemy.Enemy);
            BattleUIManager.I.StatusPanel.Move(false);

            yield return new WaitForSeconds(0.7f);

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
            if (!isWin)
            {
                // 敗北時はHPを1にしておく
                Player.Status.Health = 1;
            }

            MasterAudio.FadeOutAllOfSound("Battle_001", 0.2f);
            MasterAudio.PlaySound("Jingle_001");

            // 勝利・敗北メッセージ
            int gainExpAmount = Enemies.Select(enemy => enemy.Status.Exp)
                           .Sum();
            string playerName = (Player as Player).CharaName;
            var logMessage = isWin ? BattleLog.GetBattleWinMessage(playerName, gainExpAmount)
                                              : BattleLog.GetBattleLoseMessage(playerName);
            BattleUIManager.I.BattleLog.SetMessage(logMessage);

            yield return new WaitForSeconds(1.5f);

            // 経験値加算処理・レベルアップ
            yield return GainExp(gainExpAmount);

            if (isWin)
            {
                //勝利時のみドロップ判定
                yield return CheckDropItem();
            }

            yield return new WaitForSeconds(2.5f);

            OnEndFinishBattle();
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
            var wait = new WaitForSeconds(1);
            foreach (Enemy enemy in Enemies)
            {
                if (!enemy.IsEmpty)
                {
                    var random = UnityEngine.Random.Range(0, 101);
                    if (random <= enemy.DropItem.DropRate)
                    {
                        // ドロップした
                        Global.Inventory.AddItem(enemy.DropItem.Item);

                        var message = BattleLog.GetDropItemMessage(enemy.CharaName, enemy.DropItem.Item.Name);
                        BattleUIManager.I.BattleLog.SetMessage(message);

                        yield return wait;
                    }
                }
            }
        }

        private IEnumerator StartEnemiesTurn()
        {
            State = BattleState.Enemy;

            var attackers = Enemies
                .Select(enemy => enemy as Enemy)
                .Where(enemy => !enemy.IsEmpty && !enemy.IsDead)
                .ToList();

            foreach (var enemy in attackers)
            {
                if (CheckPlayerDead())
                {
                    break;
                }

                enemy.Attack(Player);
                MasterAudio.PlaySound("EnemyHit");

                yield return new WaitForSeconds(1.0f);
            }

            // Enemyターン終了
            yield return OnEndEnemyTurn();
        }

        /// <summary>
        /// プレイヤーターン開始時
        /// </summary>
        private void OnStartPlayerTurn()
        {
            State = BattleState.Player;
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
                yield break;
            }

            yield return new WaitForSeconds(1.0f);

            yield return StartEnemiesTurn();

            Debug.Log("OnEndPlayerTurn");
        }

        private IEnumerator OnEndEnemyTurn()
        {
            if (CheckPlayerDead())
            {
                yield return FinishBattle(false);
            } else
            {
                OnStartPlayerTurn();
            }
        }

        private bool CheckPlayerDead()
        {
            return Player.IsDead;
        }

        private bool CheckEnemiesDead()
        {
            return Enemies.Select(enemy => enemy as Enemy)
                          .All(enemy => enemy.IsDead || enemy.IsEmpty);
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