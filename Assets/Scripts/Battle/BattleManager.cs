using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.SceneManagement;

namespace CCG
{
    public class BattleManager
    {
        #region inner classes
        public class BattleSetupData
        {
            public Player Player { get; private set; }
            public List<EnemyVO> Enemies { get; private set; }

            public BattleSetupData(Player player, List<EnemyVO> enemies)
            {
                Player = player;
                Enemies = enemies;
            }
        }
        #endregion

        #region properties
        public Player Player { get; private set; }
        public List<EnemyVO> Enemies { get; private set; }

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
        public void OnSelectEnemy(IBattleCharacter target)
        {
            if (!IsMyTurn)
            {
                Debug.Log("自分のターンではありません");
                return;
            }

            // ダメージを与える
            target.Damage(Player.PlayerStatus.ATK);
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
        #endregion
    }
}