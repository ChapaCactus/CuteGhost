using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CCG
{
    public class TitleUIManager : SingletonMonoBehaviour<TitleUIManager>
    {
        #region variables
        [SerializeField]
        private Button startGameButton = null;

        [SerializeField]
        private Button fishingGameButton = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            InitUI();
        }
        #endregion

        #region public methods
        #endregion

        #region private methods
        private void InitUI()
        {
            startGameButton.onClick.AddListener(OnClickStartGameButton);
            fishingGameButton.onClick.AddListener(OnClickFishingGameButton);
        }

        private void OnClickStartGameButton()
        {
            SceneManager.LoadScene("Main");
        }

        private void OnClickFishingGameButton()
        {
            SceneManager.LoadScene("Main");
        }
        #endregion
    }
}