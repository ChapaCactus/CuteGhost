﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    public class FadeCanvas : SingletonMonoBehaviour<FadeCanvas>
    {
        #region constants
        private const string PrefabPath = "Prefabs/UI/FadeCanvas";
        #endregion

        #region variables
        [SerializeField]
        private Image image = null;
        #endregion

        #region properties
        private Tween Tween { get; set; }
        #endregion

        #region public methods
        public static FadeCanvas Create(Transform parent = null)
        {
            var prefab = Resources.Load<FadeCanvas>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Init()
        {
            SetRaycastTarget(false);
            SetAlpha(0);
            DontDestroyOnLoad(this);
        }

        public void FadeIn(Action onComplete = null)
        {
            SetRaycastTarget(true);
            Fade(1, 0, 1, onComplete);
        }

        public void FadeOut(Action onComplete = null)
        {
            SetRaycastTarget(true);
            Fade(0, 1, 1, onComplete);
        }

        public void SetRaycastTarget(bool isRaycastTarget)
        {
            image.raycastTarget = isRaycastTarget;
        }
        #endregion

        #region private methods
        private void Fade(float from, float to, float duration, Action onComplete)
        {
            if (Tween != null)
            {
                Tween.Kill();
            }

            SetAlpha(from);
            Tween = image.DOFade(to, duration)
                         .OnComplete(() =>
                         {
                             Tween = null;
                             onComplete.SafeCall();
                         });
        }

        private void SetAlpha(float alpha)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
        #endregion
    }
}