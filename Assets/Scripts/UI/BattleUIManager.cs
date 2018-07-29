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
        private AnnounceText announceText = null;
        #endregion

        #region public methods
        public void ShowAnnounceMessage(string message, float fadeDelay = 1)
        {
            announceText.ShowMessage(message, fadeDelay);
        }
        #endregion
    }
}