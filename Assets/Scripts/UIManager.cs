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
        private Bands bands = null;
        // アクションボタン
        [SerializeField]
        private Button actionButton = null;
        [SerializeField]
        private Text actionButtonText = null;
        // 設定ボタン
        [SerializeField]
        private Button settingButton = null;
        // 設定パネル
        [SerializeField]
        private SettingPanel settingPanel = null;

        [SerializeField]
        private AnnounceText announceText = null;

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

            settingButton.onClick.AddListener(OnClickSettingButton);

            InitUI();
        }
        #endregion

        #region public methods
        public void ShowAnnounceMessage(string message, float fadeDelay = 1)
        {
            announceText.ShowMessage(message, fadeDelay);
        }

        public void OnInsightTarget(GhostSight.Result result)
        {
            switch (result.targetTag)
            {
                case GhostSight.TargetTag.NPC:
                    // NPC表示設定
                    var npc  = result.target.GetComponent<NPC>();
                    npc.ShowMark(true);

                    SetActionButtonText("Talk");
                    actionButton.onClick.RemoveAllListeners();
                    actionButton.onClick.AddListener(() =>
                    {
                        OnClickTalkButton(result);
                    });
                    break;
            }
        }

        public void OnExitInsightTarget(GhostSight.Result result)
        {
            SetActionButtonText(DefaultActionButtonText);
            actionButton.onClick.RemoveAllListeners();

            switch(result.targetTag)
            {
                case GhostSight.TargetTag.NPC:
                    // NPC表示設定
                    var npc = result.target.GetComponent<NPC>();
                    npc.ShowMark(false);
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

        public Bands GetBands()
        {
            return bands;
        }
        #endregion

        #region private methods
        private void InitUI()
        {
            settingPanel.SetActive(false);

            actionButtonText.text = DefaultActionButtonText;
        }

        /// <summary>
        /// 設定ボタン押下時
        /// </summary>
        private void OnClickSettingButton()
        {
            settingPanel.SetActive(!settingPanel.gameObject.activeSelf);
        }

        private void OnClickTalkButton(GhostSight.Result result)
        {
            // 会話中なら読み進める
            if (TalkManager.I.IsTalking())
            {
                TalkManager.I.Next();
            }
            else
            {
                // 会話開始
                var npc = result.target.GetComponent<NPC>();
                npc.Talk();
            }
        }
        #endregion
    }
}