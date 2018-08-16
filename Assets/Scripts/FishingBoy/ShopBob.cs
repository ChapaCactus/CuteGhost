using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class ShopBob : SingletonMonoBehaviour<ShopBob>
    {
        #region variables
        [SerializeField]
        private Transform messagePos = null;
        #endregion

        #region properties
        public Transform MessagePos { get { return messagePos; } }
        private TargetFollowText BobText { get; set; }
        #endregion

        #region public methods
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);

            if(isActive)
            {
                BobText = TargetFollowText.Create(UIManager.I.CanvasRect);
                BobText.Setup("なに買うの", MessagePos);
            } else
            {
                if (BobText != null)
                {
                    Destroy(BobText.gameObject);
                    BobText = null;
                }
            }
        }
        #endregion
    }
}