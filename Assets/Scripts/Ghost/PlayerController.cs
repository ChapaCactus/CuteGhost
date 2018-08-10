using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class PlayerController : SingletonMonoBehaviour<PlayerController>
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
            horizontal = MainUIManager.I.IsLeftButtonDown ? -1 : horizontal;
            horizontal = MainUIManager.I.IsRightButtonDown ? 1 : horizontal;
            var speed = (horizontal * MoveBuff);
            transform.localPosition += new Vector3(speed, 0, 0);

            if (horizontal != 0)
            {
                OnMove(horizontal);
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
            MainUIManager.I.OnInsightTarget();

            Debug.Log("OnInsightEnter");
        }

        private void OnInsightExit(IInsightable insightable)
        {
            insightable.OnInsightExit();

            Global.SetInsightTarget(null);
            MainUIManager.I.OnExitInsightTarget();

            Debug.Log("OnInsightExit");
        }

        private void OnMove(int horizontal)
        {
            view.Flip(horizontal < 0);
            EncounterManager.I.OnMove();
        }
        #endregion
    }
}