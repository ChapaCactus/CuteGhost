using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        #region constants
        private const string DefaultActionButtonText = "ACT";
        #endregion

        #region variables
        [SerializeField]
        private Text actionButtonText;

        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private Camera uiCamera;
        #endregion

        #region properties
        public RectTransform canvasRect { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            canvasRect = canvas.GetComponent<RectTransform>();

            InitUI();
        }
        #endregion

        #region public methods
        public void OnInsightTarget(GhostSight.TargetTag target)
        {
            switch(target)
            {
                case GhostSight.TargetTag.NPC:
                    SetActionButtonText("Talk");
                    break;
                case GhostSight.TargetTag.NotTarget:
                    SetActionButtonText(DefaultActionButtonText);
                    break;
            }
        }

        public void SetActionButtonText(string text)
        {
            actionButtonText.text = text;
        }

        public Canvas GetCanvas()
        {
            return canvas;
        }

        public Camera GetMainCamera()
        {
            return mainCamera;
        }

        public Camera GetUICamera()
        {
            return uiCamera;
        }
        #endregion

        #region private methods
        private void InitUI()
        {
            actionButtonText.text = DefaultActionButtonText;
        }
        #endregion
    }
}