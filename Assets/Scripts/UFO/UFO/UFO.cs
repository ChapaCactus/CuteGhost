using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public class UFO : SingletonMonoBehaviour<UFO>
    {
        #region variables
        [SerializeField]
        private CaptureArea captureArea = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Assert.IsNotNull(captureArea);

            captureArea.Init();
        }
        #endregion

        #region public methods
        public void Capture(ICapturable capturable)
        {
            Debug.Log($"Capture --> {capturable.GetStatus().CharaName}");
        }
        #endregion
    }
}