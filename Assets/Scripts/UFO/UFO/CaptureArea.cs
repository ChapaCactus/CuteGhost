using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public class CaptureArea : MonoBehaviour
    {
        #region constants
        public static readonly string TAG = "CaptureArea";
        #endregion

        #region public methods
        public void Init()
        {
            gameObject.tag = TAG;
        }
        #endregion
    }
}