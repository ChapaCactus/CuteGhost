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
        public class BattleSetupData
        {
            public Player Player { get; private set; }
            public List<IFightable> Enemies { get; private set; }

            public string Background { get; private set; }

            public BattleSetupData(Player player, List<IFightable> enemies, string background)
            {
                this.Player = player;
                this.Enemies = enemies;
                this.Background = background;
            }
        }
        #endregion

        #region properties
        public Player Player { get; private set; }
        public List<IFightable> Enemies { get; private set; }
        public string Background { get; private set; }

        public BattleState State { get; private set; }
        public bool IsPlayerTurn { get { return State == BattleState.Player; } }
        public bool IsEnemyTurn { get { return State == BattleState.Enemy; } }

        public ExpTable ExpTable { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BattleManager()
        {
        }

        public static BattleManager Create()
        {
            return new BattleManager();
        }

        public void StartBattle(BattleSetupData setupData)
        {
            // シーン遷移前にデータを設定しておく
            Player = setupData.Player;
            Enemies = setupData.Enemies;
            Background = setupData.Background;

            Init();

            // Battleシーンに遷移
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
            Debug.Log($"{enemy.Status.CharaName}を選択");

            if (!IsPlayerTurn)
            {
                Debug.Log("自分のターンではありません");
                yield break;
            }
            State = BattleState.EnemySelected;

            // ダメージを与える
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

            OnFinishBattle();

            yield return new WaitForSeconds(2.5f);

            // とりあえずMainシーンに返す
            SceneManager.LoadScene("Main");
        }

        private void OnFinishBattle()
        {
            // 終了時点のプレイヤーステータスを反映
            Global.Player.UpdateStatus(Player.Status);

            // プレイヤーデータをセーブ
            Global.SaveDataManager.Save();

            Release();
        }

        private IEnumerator GainExp(int gainExpAmount)
        {
            var isLevelup = Player.GainExp(gainExpAmount);

            if (isLevelup)
            {
                yield return Player.LevelUp();

                yield return GainExp(0);
            }

            yield break;
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
                yield break;
            }

            OnStartPlayerTurn();

            Debug.Log("OnEndEnemyTurn.");
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