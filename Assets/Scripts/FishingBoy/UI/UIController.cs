using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class UIController : SingletonMonoBehaviour<UIController>
    {
        #region variables
        [SerializeField]
        private Get get = null;
        #endregion

        #region properties
        public Get Get { get { return get; } }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();
        }
        #endregion

        #region private methods
        private void Init()
        {
            get.SetActive(false);
        }
        #endregion
    }
}