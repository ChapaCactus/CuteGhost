using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Com.LuisPedroFonseca.ProCamera2D;

namespace CCG
{
    [RequireComponent(typeof(ProCamera2D))]
    public class MainCamera : SingletonMonoBehaviour<MainCamera>
    {
        #region properties
        private ProCamera2D ProCamera2D { get; set; }
        private ProCamera2DShake ProCamera2DShake { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            ProCamera2D = GetComponent<ProCamera2D>();
            ProCamera2DShake = GetComponent<ProCamera2DShake>();
        }
        #endregion

        #region public methods
        public void Shake()
        {
            ProCamera2DShake.Shake("Shake");
        }
        #endregion
    }
}