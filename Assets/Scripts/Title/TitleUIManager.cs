using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CCG
{
    public class TitleUIManager : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Button newGameButton = null;

        [SerializeField]
        private Button continueGameButton = null;

        [SerializeField]
        private Button fishingGameButton = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            InitUI();
        }
        #endregion

        #region private methods
        private void InitUI()
        {
            newGameButton.onClick.AddListener(OnClickNewGameButton);
            continueGameButton.onClick.AddListener(OnClickContinueButton);
            fishingGameButton.onClick.AddListener(OnClickFishingGameButton);
        }

        private void OnClickNewGameButton()
        {
            SceneManager.LoadScene("Main");
        }

        private void OnClickContinueButton()
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