using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG.FishingBoy
{
    public class TargetFollowText : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region properties
        private Transform FollowTarget { get; set; }
        private float? Timer { get; set; } = null;
        #endregion

        #region unity callbacks
        private void Update()
        {
            if(FollowTarget != null)
            {
                var mainCamera = UIManager.I.MainCamera;
                var uiCamera = UIManager.I.UICamera;
                var canvasRect = UIManager.I.CanvasRect;
                var screenPos = Utilities.GetScreenPosition(FollowTarget.position
                                                            , canvasRect, mainCamera, uiCamera);
                SetPosition(screenPos);
            }
        }
        #endregion

        #region public methods
        public static TargetFollowText Create(Transform parent)
        {
            var prefab = Resources.Load<TargetFollowText>("Prefabs/UI/TargetFollowText");
            return Instantiate(prefab, parent);
        }

        public void Setup(string text, Transform followTarget, float? timer = null)
        {
            this.text.text = text;
            FollowTarget = followTarget;

            var mainCamera = UIManager.I.MainCamera;
            var uiCamera = UIManager.I.UICamera;
            var canvasRect = UIManager.I.CanvasRect;
            var screenPos = Utilities.GetScreenPosition(FollowTarget.position
                                                        , canvasRect, mainCamera, uiCamera);
            SetPosition(screenPos);
        }
        #endregion

        #region private methods
        private void SetPosition(Vector2 position)
        {
            transform.localPosition = position;
        }
        #endregion
    }
}