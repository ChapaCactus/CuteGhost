using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Ghost : SingletonMonoBehaviour<Ghost>
    {
        #region constants
        private const float MoveBuff = 0.01f;
        #endregion

        #region variables
        [SerializeField]
        private GhostView view = new GhostView();

        [SerializeField]
        private GhostSight sight = null;
        #endregion

        #region properties
        public bool isTalking { get; private set; } = false;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Assert.IsNotNull(sight);

            view.PlayMoveAnimation();
            sight.SetCallbacks(OnInsightEnter, OnInsightExit);
        }

        private void Update()
        {
            if(isTalking)
            {
                return;
            }

            var horizontal = 0;
            horizontal = UIManager.I.IsLeftButtonDown ? -1 : horizontal;
            horizontal = UIManager.I.IsRightButtonDown ? 1 : horizontal;
            var speed = (horizontal * MoveBuff);
            transform.localPosition += new Vector3(speed, 0, 0);

            if (horizontal != 0)
            {
                view.Flip(horizontal < 0);
            }
        }
        #endregion

        #region public methods
        public void SetIsTalking(bool isTalking)
        {
            this.isTalking = isTalking;
        }
        #endregion

        #region private methods
        private void OnInsightEnter(IInsightable insightable)
        {
            insightable.OnInsightEnter();

            Global.SetInsightTarget(insightable);
            UIManager.I.OnInsightTarget();

            Debug.Log("OnInsightEnter");
        }

        private void OnInsightExit(IInsightable insightable)
        {
            insightable.OnInsightExit();

            Global.SetInsightTarget(null);
            UIManager.I.OnExitInsightTarget();

            Debug.Log("OnInsightExit");
        }
        #endregion
    }
}