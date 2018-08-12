using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

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

        [SerializeField]
        private CurePopText curePopText = null;
        #endregion

        #region properties
        private int? healthCache { get; set; } = null;
        #endregion

        #region public methods
        public void Setup(CharacterStatus status)
        {
            if (curePopText != null
               && healthCache != null
               && status.Health > healthCache)
            {
                int cure = (status.Health - (int)healthCache);
                curePopText.Play(cure);
            }

            SetLevelText(status.Level);
            SetHealthText(status.Health, status.MaxHealth);
            SetHealthBarValue(status.Health, status.MaxHealth);

            healthCache = status.Health;
        }

        public void Move(bool isOn)
        {
            var to = isOn ? -220 : -240;
            transform.DOLocalMoveY(to, 0.3f)
                     .SetEase(Ease.InExpo);
        }

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