using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using System.Linq;

namespace CCG
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private CanvasGroup canvasGroup = null;

        [SerializeField]
        private GridLayoutGroup layout = null;
        #endregion

        #region properties
        private List<InventoryCell> Cells { get; set; } = new List<InventoryCell>();
        #endregion

        #region unity callbacks
        private void Start()
        {
            Open(10);
        }
        #endregion

        #region public methods
        public void Open(int cellCount)
        {
            Cells.Clear();

            var cellPrefab = Resources.Load<InventoryCell>("Prefabs/UI/InventoryCell");
            foreach(var loop in Enumerable.Range(0, cellCount))
            {
                var cell = Instantiate(cellPrefab, layout.transform);
                Cells.Add(cell);
            }

            SetActive(true);
        }

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