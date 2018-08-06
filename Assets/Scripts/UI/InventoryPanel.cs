using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using System.Linq;
using DarkTonic.MasterAudio;

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

        [SerializeField]
        private ItemInfoPanel itemInfoPanel = null;
        #endregion

        #region properties
        public bool IsActive { get { return gameObject.activeSelf && canvasGroup.alpha == 1; } }

        private List<InventoryCell> Cells { get; set; } = new List<InventoryCell>();
        private int SelectedCellIndex { get; set; }
        #endregion

        #region unity callbacks
        #endregion

        #region public methods
        public void Open(Item[] items)
        {
            Cells.ForEach(cell => Destroy(cell.gameObject));
            Cells.Clear();

            var cellPrefab = Resources.Load<InventoryCell>("Prefabs/UI/InventoryCell");
            foreach (var loopIndex in Enumerable.Range(0, items.Length))
            {
                var cell = Instantiate(cellPrefab, layout.transform);
                cell.SetIndex(loopIndex);
                cell.SetData(items[loopIndex]);
                cell.SetOnClick(OnClickCell);

                Cells.Add(cell);
            }

            itemInfoPanel.ResetUI();

            SetActive(true);

            OnOpen();
        }

        public void UpdateCells()
        {
            Cells.ForEach(cell => cell.UpdateUI());
        }

        public void Close()
        {
            SetActive(false);

            OnClose();
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
        private void OnClickCell(int cellIndex)
        {
            SelectedCellIndex = cellIndex;

            var item = Global.Inventory.Items[SelectedCellIndex];
            itemInfoPanel.SetItem(item);
            itemInfoPanel.SetOnClickUseButton(OnClickUseButton);
        }

        private void OnClickUseButton()
        {
            var item = Global.Inventory.Items[SelectedCellIndex];
            item.Use();
            Global.Inventory.SetEmpty(SelectedCellIndex);
            UpdateCells();
        }

        private void OnOpen()
        {
            MasterAudio.PlaySound("Beep_High");
        }

        private void OnClose()
        {
            MasterAudio.PlaySound("Beep_Low");
        }
        #endregion
    }
}