using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    /// <summary>
    /// 「！」マーク等
    /// </summary>
    public class PopMark : MonoBehaviour
    {
        #region properties
        private SpriteRenderer spriteRenderer { get; set; }
        #endregion

        #region private methods
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        #endregion

        #region public methods
        public void SetActive(bool isActive)
        {
            spriteRenderer.enabled = isActive;
        }
        #endregion
    }
}