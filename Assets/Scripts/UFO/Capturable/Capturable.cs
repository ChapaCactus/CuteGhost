using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public class Capturable : MonoBehaviour, ICapturable, IPoolable
    {
        #region properties
        public bool IsPooling { get; private set; }
        public string Uid { get; private set; }

        private CapturableStatus Status { get; set; }
        #endregion

        #region unity callbacks
        #endregion

        #region public methods
        public CapturableStatus GetStatus() => this.Status;

        public void Gain()
        {
            UFO.I.Capture(this);

            Pool();
        }

        public void Pick()
        {
            ResetPosition();

            IsPooling = false;
            SetActive(true);
        }

        public void Pool()
        {
            IsPooling = true;
            SetActive(false);
        }

        public void SetUid(string uid) => Uid = uid;
        public string GetUid() => Uid;

        public bool GetIsPooling() => IsPooling;

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

        private void ResetPosition()
        {
            var x = UnityEngine.Random.Range(-1f, 1f);
            var y = UnityEngine.Random.Range(-5.5f, -5f);
            transform.position = new Vector2(x, y);
        }
        #endregion
    }
}