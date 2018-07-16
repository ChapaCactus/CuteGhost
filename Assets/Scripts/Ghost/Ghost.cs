using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Ghost : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private GhostView view = new GhostView();

        [SerializeField]
        private GhostSight sight;
        #endregion

        #region constants
        private const float MoveBuff = 0.01f;
        #endregion

        #region properties
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
            var horizontal = Input.GetAxisRaw("Horizontal");
            var speed = (horizontal * MoveBuff);
            transform.localPosition += new Vector3(speed, 0, 0);

            if (horizontal != 0)
            {
                view.Flip(horizontal < 0);
            }
        }
        #endregion

        #region private methods
        private void OnInsightEnter(GhostSight.TargetTag target)
        {
            UIManager.I.OnInsightTarget(target);
            TextManager.I.RequestCreateMessageBalloon(gameObject, balloon =>
            {

            });

            Debug.Log("OnInsightEnter");
        }

        private void OnInsightExit()
        {
            UIManager.I.OnInsightTarget(GhostSight.TargetTag.NotTarget);

            Debug.Log("OnInsightExit");
        }
        #endregion
    }
}