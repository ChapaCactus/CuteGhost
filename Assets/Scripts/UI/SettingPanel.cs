using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DarkTonic.MasterAudio;

namespace CCG
{
    public class SettingPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Button clearAllSaveDataButton = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            clearAllSaveDataButton.onClick.AddListener(OnClickClearAllSaveDataButton);
        }
        #endregion

        #region public methods
        public void Open()
        {
            SetActive(true);
            OnOpen();
        }

        public void Close()
        {
            SetActive(false);
            OnClose();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        #endregion

        #region private methods
        private void OnClickClearAllSaveDataButton()
        {
            SetActive(false);
            Global.DeleteAllSaveData();
        }

        private void OnOpen()
        {
            MasterAudio.PlaySound("Beep_High");
        }

        private void OnClose()
        {
            MasterAudio.PlaySound("Beep_Low");
        }
        #endregion
    }
}