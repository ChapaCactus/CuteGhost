using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG
{
    public class BattleBackground : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private _2dxFX_StoneFX fx = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            DOTween.To(() => fx.Deep, change => fx.Deep = change, 0.4f, 3.0f)
                   .SetEase(Ease.Linear)
                   .SetLoops(-1, LoopType.Yoyo);
        }
        #endregion
    }
}