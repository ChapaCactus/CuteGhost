using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG.UFO
{
    public class GoldCoinText : MonoBehaviour
    {
        #region constants
        private const string UNIT_NAME = "ヤバイ";
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region public methods
        public void Init()
        {
            SetText(Global.GameData.GoldCoin);
        }

        public void SetText(int count)
        {
            text.text = $"{count} {UNIT_NAME}";
        }
        #endregion
    }
}