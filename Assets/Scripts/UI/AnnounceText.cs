using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    public class AnnounceText : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region properties
        private Tweener tweener { get; set; }
        #endregion

        #region unity callbacks
        #endregion

        #region public methods
        public void ShowMessage(string message, float fadeDelay = 1)
        {
            text.text = message;
            text.color = Color.white;
            SetVisible(true);

            if(tweener != null)
            {
                tweener.Kill();
            }
            tweener = text.DOFade(0, 0.5f)
                          .SetDelay(fadeDelay)
                          .OnComplete(() =>
            {
                SetVisible(false);
                tweener = null;
            });
        }

        public void SetVisible(bool isVisible)
        {
            text.enabled = isVisible;
        }
        #endregion
    }
}