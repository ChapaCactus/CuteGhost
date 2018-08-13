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
        private Text goldText = null;

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
        public void Setup(CharacterStatus status, int gold)
        {
            if (CheckIsCured(status.Health))
            {
                int cure = (status.Health - (int)healthCache);
                SetCurePopText(cure);
            }

            SetLevelText(status.Level);
            SetGoldText(gold);
            SetHealthText(status.Health, status.MaxHealth);
            SetHealthBarValue(status.Health, status.MaxHealth);

            healthCache = status.Health;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Move(bool isOn)
        {
            float to = isOn ? -220 : -240;
            transform.DOLocalMoveY(to, 0.3f)
                     .SetEase(Ease.InExpo);
        }

        public void SetLevelText(int level)
        {
            if (levelText == null)
                return;

            string text = $"Lv {level}";
            levelText.text = text;
        }

        public void SetGoldText(int gold)
        {
            if (goldText == null)
                return;

            string text = gold.ToString().PadLeft(10, '_');
            goldText.text = text;
        }

        public void SetHealthText(int current, int max)
        {
            if (healthText == null)
                return;

            string text = $"HP {current} / {max}";
            healthText.text = text;
        }

        public void SetCurePopText(int cure)
        {
            if (curePopText == null)
                return;

            curePopText.Play(cure);
        }

        public void SetHealthBarValue(int value, int max)
        {
            if (healthBar == null)
                return;

            healthBar.maxValue = max;
            healthBar.value = value;
        }
        #endregion

        #region private methods
        /// <summary>
        /// HPが増加しているか
        /// </summary>
        private bool CheckIsCured(int health)
        {
            return (healthCache != null) && (health > healthCache);
        }
        #endregion
    }
}