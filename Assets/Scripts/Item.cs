using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class Item
    {
        #region properties
        public string Name { get; private set; }
        public int Price { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Item(ItemMaster.rowIds id)
        {
            var row = ItemMaster.Instance.GetRow(id);

            this.Name = row._Name;
            this.Price = row._Price;
        }

        public static Item Empty()
        {
            return new Item(ItemMaster.rowIds.Empty);
        }
        #endregion
    }
}