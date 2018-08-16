using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        #region variables
        [SerializeField]
        private Get get = null;

        [SerializeField]
        private Camera mainCamera = null;
        [SerializeField]
        private Camera uiCamera = null;
        [SerializeField]
        private RectTransform canvasRect = null;
        #endregion

        #region properties
        public Get Get { get { return get; } }

        public Camera MainCamera { get { return mainCamera; } }
        public Camera UICamera { get { return uiCamera; } }
        public RectTransform CanvasRect { get { return canvasRect; } }
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