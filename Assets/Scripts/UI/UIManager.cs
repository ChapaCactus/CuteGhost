using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;

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

        // インベントリボタン
        [SerializeField]
        private Button inventoryButton = null;
        // インベントリパネル
        [SerializeField]
        private InventoryPanel inventoryPanel = null;

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
            inventoryButton.onClick.AddListener(OnClickInventoryButton);

            IsLeftButtonDown = false;
            IsRightButtonDown = false;
            // アクションボタン初期化
            SetActionButtonText(DefaultActionButtonText);
            actionButton.interactable = false;

            announceText.SetVisible(false);

            InitUI();
        }
        #endregion

        #region public methods
        public void SetupStatusPanel(CharacterStatus status)
        {
            statusPanel.Setup(status);
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

                MasterAudio.PlaySound("Beep_High");
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
            inventoryPanel.SetActive(false);

            actionButtonText.text = DefaultActionButtonText;
        }

        /// <summary>
        /// 設定ボタン押下時
        /// </summary>
        private void OnClickSettingButton()
        {
            if(settingPanel.gameObject.activeSelf)
            {
                settingPanel.Close();
            } else
            {
                // 他のパネル非表示
                inventoryPanel.SetActive(false);
                // 開く
                settingPanel.Open();
            }
        }

        private void OnClickInventoryButton()
        {
            if (inventoryPanel.IsActive)
            {
                inventoryPanel.Close();
            }
            else
            {
                // 他のパネル非表示
                settingPanel.SetActive(false);
                // 開く
                inventoryPanel.Open(Global.Inventory.Items);
            }
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