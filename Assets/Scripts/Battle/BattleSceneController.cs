using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleSceneController : SingletonMonoBehaviour<BattleSceneController>
    {
        #region unity callbacks
        private void Awake()
        {
            // BattleScene開始タイミング
        }
        #endregion

        #region public methods
        public void OnClickEnemy(Enemy enemy)
        {
            Global.BattleManager.OnSelectEnemy(enemy);
        }
        #endregion
    }
}