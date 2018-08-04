using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class ItemInfoPanel : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text itemNameText = null;
        #endregion

        #region public methods
        public void SetItem(Item item)
        {
            itemNameText.text = item.Name;
        }
        #endregion
    }
}