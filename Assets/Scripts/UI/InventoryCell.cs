using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class InventoryCell : MonoBehaviour
    {
        #region variables
        /// <summary>
        /// デバッグ用テキスト
        /// </summary>
        [SerializeField]
        private Text text = null;

        [SerializeField]
        private Button button = null;

        private Action<int> onClick = null;
        #endregion

        #region properties
        public int Index { get; private set; }
        #endregion

        #region public methods
        public void SetOnClick(Action<int> onClick)
        {
            this.onClick = onClick;
            button.onClick.AddListener(OnClick);
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public void SetData(Item item)
        {
            text.text = item.Name;

            button.interactable = (item.Name != "Empty");
        }

        public void UpdateUI()
        {
            var item = Global.Inventory.Items[Index];
            SetData(item);
        }
        #endregion

        #region private methods
        private void OnClick()
        {
            onClick.SafeCall(Index);
        }
        #endregion
    }
}