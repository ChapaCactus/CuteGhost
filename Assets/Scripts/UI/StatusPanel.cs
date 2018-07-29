using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class StatusPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text levelText = null;

        [SerializeField]
        private Text healthText = null;

        [SerializeField]
        private Slider healthBar = null;
        #endregion

        #region public methods
        public void SetLevelText(int level)
        {
            var text = $"Lv {level}";
            levelText.text = text;
        }

        public void SetHealthText(int current, int max)
        {
            var text = $"HP {current} / {max}";
            healthText.text = text;
        }

        public void SetHealthBarValue(int value, int max)
        {
            healthBar.maxValue = max;
            healthBar.value = value;
        }
        #endregion
    }
}