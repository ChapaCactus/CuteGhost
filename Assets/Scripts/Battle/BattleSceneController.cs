﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class BattleSceneController : SingletonMonoBehaviour<BattleSceneController>
    {
        #region variables
        [SerializeField]
        private bool isDebugMode = false;

        [SerializeField]
        private List<BattleEnemyController> battleEnemies = new List<BattleEnemyController>();
        #endregion

        #region unity callbacks
        private void Awake()
        {
            if(isDebugMode)
            {
                Global.Init();
                // デバッグモードならここでプレイヤー・敵データを設定する
                Global.BattleManager.LoadDummyPlayerData();
                Global.BattleManager.LoadDummyEnemyData();
            }

            // BattleScene開始タイミング
            for (int i = 0; i < battleEnemies.Count; i++)
            {
                battleEnemies[i].Setup(Global.BattleManager.Enemies[i] as Enemy);
            }

            // Enemyデータが設定されているControllerのみActive
            battleEnemies.ForEach(enemy => enemy.gameObject.SetActive(enemy.Enemy != null));
        }

        private void Start()
        {
            Global.BattleManager.PrepareBattle();

            BattleUIManager.I.ShowAnnounceMessage("バトルかいし！");
        }
        #endregion

        #region public methods
        public void OnClickEnemy(BattleEnemyController enemy)
        {
            Global.BattleManager.OnSelectEnemy(enemy);
        }
        #endregion
    }
}