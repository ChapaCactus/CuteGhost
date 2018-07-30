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
        private const string DefaultActionButtonText = "?";
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
        private ChoisesPanel choisesPanel = null;

        [SerializeField]
        private StatusPanel statusPanel = null;

        [SerializeField]
        private Canvas canvas = null;
        [SerializeField]
        private Camera mainCamera = null;
        [SerializeField]
        private Camera uiCamera = null;
        #endregion

        #region properties
        public RectTransform canvasRect { get; private set; }

        public bool IsLeftButtonDown { get; private set; }
        public bool IsRightButtonDown { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            canvasRect = canvas.GetComponent<RectTransform>();

            settingButton.onClick.AddListener(OnClickSettingButton);

            IsLeftButtonDown = false;
            IsRightButtonDown = false;
            // アクションボタン初期化
            SetActionButtonText(DefaultActionButtonText);
            actionButton.interactable = false;

            InitUI();
        }
        #endregion

        #region public methods
        public void SetStatusPanel(CharacterStatus status)
        {
            statusPanel.SetLevelText(status.Level);
            statusPanel.SetHealthText(status.Health, status.MaxHealth);
            statusPanel.SetHealthBarValue(status.Health, status.MaxHealth);
        }

        /// <summary>
        /// 選択肢パネルを開く
        /// </summary>
        public void OpenChoisesPanel(Action onClickYes, Action onClickNo)
        {
            choisesPanel.Open(onClickYes, onClickNo);
        }

        public void ShowAnnounceMessage(string message, float fadeDelay = 1)
        {
            announceText.ShowMessage(message, fadeDelay);
        }

        public void OnLeftButtonDown()
        {
            IsLeftButtonDown = true;
        }

        public void OnLeftButtonUp()
        {
            IsLeftButtonDown = false;
        }

        public void OnRightButtonDown()
        {
            IsRightButtonDown = true;
        }

        public void OnRightButtonUp()
        {
            IsRightButtonDown = false;
        }

        public void OnInsightTarget()
        {
            SetActionButtonText("Talk");
            actionButton.interactable = true;

            actionButton.onClick.RemoveAllListeners();
            actionButton.onClick.AddListener(() =>
            {
                OnClickTalkButton();
            });
        }

        public void OnExitInsightTarget()
        {
            SetActionButtonText(DefaultActionButtonText);
            actionButton.interactable = false;

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

        private void OnClickTalkButton()
        {
            // 会話中なら読み進める
            if (TalkManager.I.IsTalking())
            {
                TalkManager.I.Next();
            }
            else
            {
                // 会話開始
                Global.InsightTarget.Action();
            }
        }
        #endregion
    }
}