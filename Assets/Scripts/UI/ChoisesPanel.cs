using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class ChoisesPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Button yesButton = null;

        [SerializeField]
        private Button noButton = null;
        #endregion

        #region properties
        private Action onClickYes { get; set; }
        private Action onClickNo { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            yesButton.onClick.AddListener(OnClickYes);
            noButton.onClick.AddListener(OnClickNo);
        }
        #endregion

        #region public methods
        public void Open(Action onClickYes, Action onClickNo)
        {
            this.onClickYes = onClickYes;
            this.onClickNo = onClickNo;

            SetActive(true);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        #endregion

        #region private methods
        private void OnClickYes()
        {
            onClickYes.SafeCall();

            SetActive(false);
        }

        private void OnClickNo()
        {
            onClickNo.SafeCall();

            SetActive(false);
        }
        #endregion
    }
}