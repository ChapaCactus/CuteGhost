using System;
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
        public async void OnSelectEnemy(BattleEnemyController enemy)
        {
            Debug.Log($"{enemy.Status.CharaName}を選択");

            if (!IsPlayerTurn)
            {
                Debug.Log("自分のターンではありません");
                return;
            }

            // ダメージを与える
            Player.Attack(enemy.Enemy);

            await Task.Delay(700);

            await enemy.PlayDamageEffect();

            // Playerターン終了
            OnEndPlayerTurn();
        }

        public void LoadDummyPlayerData()
        {
            var status = new CharacterStatus();
            status.CharaName = "デバッグプレイヤー";
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
            var enemy1 = new Enemy(EnemyMaster.rowIds.ID_001.ToString());
            var enemy2 = new Enemy(EnemyMaster.rowIds.ID_001.ToString());
            var enemy3 = new Enemy(EnemyMaster.rowIds.ID_001.ToString());

            Enemies = new List<IFightable>();
            Enemies.Add(enemy1);
            Enemies.Add(enemy2);
            Enemies.Add(enemy3);

            Debug.Log("Dummy EnemyData Loaded.");
        }
        #endregion

        #region private methods
        private async void FinishBattle(bool isWin)
        {
            await Task.Delay(1000);

            // とりあえずMainシーンに返す
            SceneManager.LoadScene("Main");
        }

        private async void StartEnemiesTurn()
        {
            Turn = BattleTurn.Enemy;

            var attackers = Enemies.Where(enemy => !enemy.IsDead)
                                   .ToList();

            foreach(var enemy in attackers)
            {
                enemy.Attack(Player);
                MasterAudio.PlaySound("Beep_High");

                await Task.Delay(1000);
            }

            // Enemyターン終了
            OnEndEnemyTurn();
        }

        private async void OnEndPlayerTurn()
        {
            bool isAllEnemiesDead = Enemies.All(enemy => enemy.IsDead);
            if(isAllEnemiesDead)
            {
                FinishBattle(true);
                return;
            }

            await Task.Delay(1000);

            StartEnemiesTurn();

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