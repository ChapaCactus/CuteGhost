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
        #endregion

        #region properties
        public int Index { get; private set; }
        #endregion

        #region public methods
        public void SetOnClick(Action<int> onClick)
        {
            button.onClick.AddListener(() => onClick.SafeCall(Index));
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public void SetData(Item item)
        {
            text.text = item.Name;
        }
        #endregion
    }
}