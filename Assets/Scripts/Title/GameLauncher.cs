using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    /// <summary>
    /// ゲーム開始クラス
    /// </summary>
    public class GameLauncher : MonoBehaviour
    {
        #region unity callbacks
        private void Awake()
        {
            Global.Init();

            Debug.Log("Game Launched.");
        }
        #endregion
    }
}