using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public class Capturable : MonoBehaviour, ICapturable
    {
        #region properties
        private CapturableStatus Status { get; set; }
        #endregion

        #region public methods
        public CapturableStatus GetStatus() => this.Status;

        public void Gain()
        {
            UFO.I.Capture(this);

            SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        #endregion

        #region private methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(CaptureArea.TAG))
            {
                Gain();
            }
        }
        #endregion
    }
}