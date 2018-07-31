using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleUIManager : SingletonMonoBehaviour<BattleUIManager>
    {
        #region variables
        [SerializeField]
        private BattleLog battleLog = null;

        [SerializeField]
        private StatusPanel statusPanel = null;
        #endregion

        #region properties
        public BattleLog BattleLog { get { return battleLog; } }
        public StatusPanel StatusPanel { get { return statusPanel; } }
        #endregion
    }
}