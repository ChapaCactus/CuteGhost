using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using DarkTonic.MasterAudio;

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

            // ステータスパネル初期化
            BattleUIManager.I.StatusPanel.Setup(Global.Player.Status);

            // Enemyデータが設定されているControllerのみActive
            battleEnemies.ForEach(enemy => enemy.gameObject.SetActive(enemy.Enemy != null));


        }

        private void Start()
        {
            MasterAudio.PlaySound("Battle_001");

            Global.BattleManager.PrepareBattle();

            BattleUIManager.I.BattleLog.SetMessage("バトルかいし！");
        }
        #endregion

        #region public methods
        public void OnClickEnemy(BattleEnemyController enemy)
        {
            StartCoroutine(Global.BattleManager.OnSelectEnemy(enemy));
        }
        #endregion
    }
}