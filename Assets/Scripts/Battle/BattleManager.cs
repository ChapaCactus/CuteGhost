using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using UnityEngine.SceneManagement;
using Google2u;

namespace CCG
{
    public enum BattleTurn
    {
        Player,
        Enemy,
    }

    public class BattleManager
    {
        #region inner classes
        public class BattleSetupData
        {
            public IFightable Player { get; private set; }
            public List<IFightable> Enemies { get; private set; }

            public BattleSetupData(IFightable player, List<IFightable> enemies)
            {
                Player = player;
                Enemies = enemies;
            }
        }
        #endregion

        #region properties
        public IFightable Player { get; private set; }
        public List<IFightable> Enemies { get; private set; }

        public BattleTurn Turn { get; private set; }
        public bool IsPlayerTurn { get { return Turn == BattleTurn.Player; } }
        public bool IsEnemyTurn { get { return Turn == BattleTurn.Enemy; } }
        #endregion

        #region public methods
        public void Init()
        {
        }

        public void StartBattle(BattleSetupData setupData)
        {
            // シーン遷移前にデータを設定しておく
            Player = setupData.Player;
            Enemies = setupData.Enemies;

            // Battleシーンに遷移
            SceneManager.LoadScene("Battle");
        }

        public void PrepareBattle()
        {
            Turn = BattleTurn.Player;
        }

        /// <summary>
        /// 敵キャラクター選択時
        /// 自分のターン時のみ実行出来る
        /// </summary>
        public void OnSelectEnemy(Enemy enemy)
        {
            Debug.Log($"{enemy.Status.Name}を選択");

            if (!IsPlayerTurn)
            {
                Debug.Log("自分のターンではありません");
                return;
            }

            // ダメージを与える
            Player.Attack(enemy);

            // Playerターン終了
            OnEndPlayerTurn();

            StartEnemiesTurn();
        }

        public void LoadDummyPlayerData()
        {
            var status = new CharacterStatus();
            status.Name = "デバッグプレイヤー";
            status.Level = 1;
            status.MaxHealth = 10;
            status.Health = 10;
            status.ATK = 500;
            var player = new Player(status);

            Player = player;

            Debug.Log("Dummy PlayerData Loaded.");
        }

        public void LoadDummyEnemyData()
        {
            var enemy1Status = new CharacterStatus();
            var enemy1Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy1Status.SetData(enemy1Row);
            var enemy1 = new Enemy(enemy1Status);

            var enemy2Status = new CharacterStatus();
            var enemy2Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy2Status.SetData(enemy2Row);
            var enemy2 = new Enemy(enemy2Status);

            var enemy3Status = new CharacterStatus();
            var enemy3Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy3Status.SetData(enemy3Row);
            var enemy3 = new Enemy(enemy3Status);

            Enemies = new List<IFightable>();
            Enemies.Add(enemy1);
            Enemies.Add(enemy2);
            Enemies.Add(enemy3);

            Debug.Log("Dummy EnemyData Loaded.");
        }
        #endregion

        #region private methods
        private void FinishBattle(bool isWin)
        {
            // とりあえずMainシーンに返す
            SceneManager.LoadScene("Main");
        }

        private void StartEnemiesTurn()
        {
            Enemies.ForEach(enemy =>
            {
                enemy.Attack(Player);
            });

            // Enemyターン終了
            OnEndEnemyTurn();
        }

        private void OnEndPlayerTurn()
        {
            bool isAllEnemiesDead = Enemies.All(enemy => enemy.IsDead);
            if(isAllEnemiesDead)
            {
                FinishBattle(true);
                return;
            }

            Turn = BattleTurn.Enemy;

            Debug.Log("OnEndPlayerTurn");
        }

        private void OnEndEnemyTurn()
        {
            Turn = BattleTurn.Player;

            Debug.Log("OnEndEnemyTurn.");
        }

        private bool CheckPlayerDead()
        {
            return Player.IsDead;
        }

        private bool CheckEnemiesDead()
        {
            return Enemies.All(enemy => enemy.IsDead);
        }
        #endregion
    }
}