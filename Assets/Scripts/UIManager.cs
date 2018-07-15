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
        #endregion

        #region unity callbacks
        private void Awake()
        {
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
        #endregion

        #region private methods
        private void InitUI()
        {
            actionButtonText.text = DefaultActionButtonText;
        }
        #endregion
    }
}