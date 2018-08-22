using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    /// <summary>
    /// UFO用ステージ起動クラス
    /// </summary>
    public class StageLauncher : MonoBehaviour
    {
        #region unity callbacks
        private void Awake()
        {
            Launch();
        }
        #endregion

        #region private methods
        private void Launch()
        {
            UIManager.I.Init();

            Debug.Log("Stage Launched.");
        }
        #endregion
    }
}