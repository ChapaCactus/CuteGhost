using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    public class Bands : MonoBehaviour
    {
        #region constants
        private readonly Vector2 UpperInPos = new Vector2(0, 450);
        private readonly Vector2 UpperOutPos = new Vector2(0, 550);
        private readonly Vector2 LowerInPos = new Vector2(0, -450);
        private readonly Vector2 LowerOutPos = new Vector2(0, -550);

        private const float TweenDuration = 0.3f;
        #endregion

        #region variables
        [SerializeField]
        private Image upperBand = null;

        [SerializeField]
        private Image lowerBand = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            upperBand.transform.localPosition = UpperOutPos;
            lowerBand.transform.localPosition = LowerOutPos;
        }
        #endregion

        #region public methods
        public void FrameIn(bool upper, bool lower)
        {
            if (upper)
            {
                UpperFrameIn();
            }

            if (lower)
            {
                LowerFrameIn();
            }
        }

        public void FrameOut(bool upper, bool lower)
        {
            if (upper)
            {
                UpperFrameOut();
            }

            if (lower)
            {
                LowerFrameOut();
            }
        }
        #endregion

        #region private methods
        private void UpperFrameIn()
        {
            upperBand.transform.DOLocalMove(UpperInPos, TweenDuration)
                     .SetEase(Ease.Linear);
        }

        private void UpperFrameOut()
        {
            upperBand.transform.DOLocalMove(UpperOutPos, TweenDuration)
                     .SetEase(Ease.Linear);
        }

        private void LowerFrameIn()
        {
            lowerBand.transform.DOLocalMove(LowerInPos, TweenDuration)
                     .SetEase(Ease.Linear);
        }

        private void LowerFrameOut()
        {
            lowerBand.transform.DOLocalMove(LowerOutPos, TweenDuration)
                     .SetEase(Ease.Linear);
        }
        #endregion
    }
}