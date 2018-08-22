using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG.UFO
{
    /// <summary>
    /// UFO用UIManager
    /// </summary>
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        #region variables
        [SerializeField]
        private SilverCoinText silverCoinText = null;

        [SerializeField]
        private GoldCoinText goldCoinText = null;
        #endregion

        #region public methods
        public void Init()
        {
            silverCoinText.Init();
            goldCoinText.Init();
        }
        #endregion
    }
}