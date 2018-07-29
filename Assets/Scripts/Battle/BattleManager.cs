using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using UnityEngine.SceneManagement;
using Google2u;

namespace CCG
{
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

        public bool IsMyTurn { get; private set; }
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

        /// <summary>
        /// 敵キャラクター選択時
        /// 自分のターン時のみ実行出来る
        /// </summary>
        public void OnSelectEnemy(Enemy enemy)
        {
            Debug.Log($"{enemy.Status.Name}を選択");

            if (!IsMyTurn)
            {
                Debug.Log("自分のターンではありません");
                return;
            }

            // ダメージを与える
            enemy.Damage(Player.Status.ATK);
            OnEndMyTurn();

            StartEnemiesTurn();
        }

        public void LoadDummyPlayerData()
        {
            var status = new CharacterStatus();
            status.Level = 1;
            status.MaxHealth = 10;
            status.Health = 10;
            status.ATK = 5;
            var player = new Player(status);

            Player = Player;
        }

        public void LoadDummyEnemyData()
        {
            var enemy1Status = new CharacterStatus();
            var enemy1Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy1Status.SetData(enemy1Row);
            var enemy1 = new Enemy(enemy1Status);

            var enemy2Status = new CharacterStatus();
            var enemy2Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy2Status.SetData(enemy1Row);
            var enemy2 = new Enemy(enemy1Status);

            var enemy3Status = new CharacterStatus();
            var enemy3Row = EnemyMaster.Instance.GetRow(EnemyMaster.rowIds.ID_001);
            enemy3Status.SetData(enemy1Row);
            var enemy3 = new Enemy(enemy1Status);

            Enemies = new List<IFightable>();
            Enemies.Add(enemy1);
            Enemies.Add(enemy2);
            Enemies.Add(enemy3);
        }
        #endregion

        #region private methods
        private void StartEnemiesTurn()
        {
            OnEndEnemyTurn();
        }

        private void OnEndMyTurn()
        {
            IsMyTurn = false;
        }

        private void OnEndEnemyTurn()
        {
            IsMyTurn = true;
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