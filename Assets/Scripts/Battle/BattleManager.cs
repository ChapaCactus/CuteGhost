using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using UnityEngine.SceneManagement;

namespace CCG
{
    public class BattleManager
    {
        #region inner classes
        public class BattleSetupData
        {
            public IBattleCharacter Player { get; private set; }
            public List<IBattleCharacter> Enemies { get; private set; }

            public BattleSetupData(IBattleCharacter player, List<IBattleCharacter> enemies)
            {
                Player = player;
                Enemies = enemies;
            }
        }
        #endregion

        #region properties
        public IBattleCharacter Player { get; private set; }
        public List<IBattleCharacter> Enemies { get; private set; }

        public bool IsMyTurn { get; private set; }
        #endregion

        #region public methods
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
        public void OnSelectEnemy(int enemyIndex)
        {
            if (!IsMyTurn)
            {
                Debug.Log("自分のターンではありません");
                return;
            }

            var target = Enemies[enemyIndex];

            // ダメージを与える
            target.Damage(Player.Status.ATK);
            OnEndMyTurn();

            StartEnemiesTurn();
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