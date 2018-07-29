using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

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
            UIManager.I.ShowAnnounceMessage("全セーブデータを削除\nしました。(再起動後有効)");
        }
        #endregion
    }
}