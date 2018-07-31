﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;

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
            MasterAudio.PlaySound("Field_002");
        }
        #endregion
    }
}