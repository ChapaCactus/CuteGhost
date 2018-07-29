using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleSceneController : MonoBehaviour
    {
        #region unity callbacks
        private void Awake()
        {
            // BattleScene開始タイミング
        }
        #endregion

        #region public methods
        public void OnClickEnemy(IBattleCharacter target)
        {
        }
        #endregion
    }
}