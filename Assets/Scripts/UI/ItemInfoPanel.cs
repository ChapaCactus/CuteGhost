using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class ItemInfoPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text itemNameText = null;

        [SerializeField]
        private Text descriptionText = null;

        [SerializeField]
        private Button useButton = null;

        private Action onClickUseButton = null;
        #endregion

        #region unity callback
        private void Awake()
        {
            useButton.onClick.AddListener(OnClickUseButton);
        }
        #endregion

        #region public methods
        public void SetItem(Item item)
        {
            itemNameText.text = item.Name;
            descriptionText.text = item.Description;
        }

        public void SetOnClickUseButton(Action onClickUseButton)
        {
            this.onClickUseButton = onClickUseButton;
        }
        #endregion

        #region private methods
        private void OnClickUseButton()
        {
            onClickUseButton.SafeCall();
        }
        #endregion
    }
}