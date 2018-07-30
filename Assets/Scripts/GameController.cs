using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class GameController : SingletonMonoBehaviour<GameController>
    {
        #region unity callbacks
        private void Awake()
        {
            Global.Init();

            UIManager.I.SetupStatusPanel(Global.Player.Status);
        }

        private void Start()
        {
            UIManager.I.ShowAnnounceMessage("はじまり　はじまり", 1);
        }
        #endregion
    }
}