using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private CanvasGroup canvasGroup = null;
        #endregion

        #region properties
        private List<InventoryCell> Cells { get; set; }
        #endregion

        #region unity callbacks
        #endregion

        #region public methods
        public void SetActive(bool isActive)
        {
            Assert.IsNotNull(canvasGroup);

            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            canvasGroup.alpha = isActive ? 1 : 0;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }
        #endregion

        #region private methods
        #endregion
    }
}