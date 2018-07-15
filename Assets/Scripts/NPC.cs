using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG
{
    public class NPC : MonoBehaviour
    {
        #region unity callback
        private void Awake()
        {
            transform.DOLocalMoveY(1f, 1)
                     .SetLoops(-1, LoopType.Yoyo)
                     .SetEase(Ease.Linear)
                     .SetRelative();
        }
        #endregion
    }
}