using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG
{
    [Serializable]
    public class GhostView
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        #endregion

        #region public methods
        public void PlayMoveAnimation()
        {
            spriteRenderer.transform.DOLocalMoveY(0.07f, 1.5f)
                          .SetLoops(-1, LoopType.Yoyo)
                          .SetEase(Ease.InOutSine)
                          .SetRelative();
        }

        public void Flip(bool isFlip)
        {
            spriteRenderer.flipX = isFlip;
        }
        #endregion
    }
}