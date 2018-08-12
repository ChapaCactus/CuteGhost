using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;

namespace CCG
{
    public class MainSceneController : SingletonMonoBehaviour<MainSceneController>
    {
        #region unity callbacks
        private void Awake()
        {
            if(!Global.IsGameInitialized)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
                return;
            }

            MainUIManager.I.SetupStatusPanel(Global.Player.Status);
            MasterAudio.PlaySound("Field_002");

            if (Global.BattleManager.StartScene != "None")
            {
                PlayerController.I.SetPosition(Global.BattleManager.StartPosition);
            }

            FadeCanvas.I.FadeIn(() => 
            {
                FadeCanvas.I.SetRaycastTarget(false);
            });
        }
        #endregion
    }
}