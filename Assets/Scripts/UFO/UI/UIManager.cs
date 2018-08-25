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
        private CoinText coinText = null;
        #endregion

        #region public methods
        public void Init()
        {
            coinText.Init();
        }

        public void OnUpdateCoin()
        {
            coinText.SetText(Global.GameData.Coin);
        }
        #endregion
    }
}