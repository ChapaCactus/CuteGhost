using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG.UFO
{
    public class SilverCoinText : MonoBehaviour
    {
        #region constants
        private const string UNIT_NAME = "イイネ";
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region public methods
        public void Init()
        {
            SetText(Global.GameData.SilverCoin);
        }

        public void SetText(int count)
        {
            text.text = $"{count} {UNIT_NAME}";
        }
        #endregion
    }
}