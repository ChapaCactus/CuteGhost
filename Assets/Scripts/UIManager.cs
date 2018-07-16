﻿using System;
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
        private Button actionButton = null;
        [SerializeField]
        private Text actionButtonText = null;

        [SerializeField]
        private Canvas canvas = null;
        [SerializeField]
        private Camera mainCamera = null;
        [SerializeField]
        private Camera uiCamera = null;
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
        public void OnInsightTarget(GhostSight.Result result)
        {
            switch(result.targetTag)
            {
                case GhostSight.TargetTag.NPC:
                    SetActionButtonText("Talk");
                    actionButton.onClick.RemoveAllListeners();
                    actionButton.onClick.AddListener(() =>
                    {
                        // ACTボタン押下で会話
                        var npc = result.target.GetComponent<NPC>();
                        npc.Talk();
                    });
                    break;
            }
        }

        public void OnExitInsightTarget()
        {
            SetActionButtonText(DefaultActionButtonText);
            actionButton.onClick.RemoveAllListeners();
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