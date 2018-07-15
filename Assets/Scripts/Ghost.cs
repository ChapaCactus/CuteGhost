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
        #endregion

        #region constants
        private const float MoveBuff = 0.01f;
        #endregion

        #region properties
        #endregion

        #region unity callbacks
        private void Awake()
        {
            view.PlayMoveAnimation();
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
        #endregion
    }
}