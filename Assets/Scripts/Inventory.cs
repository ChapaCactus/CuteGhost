using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class Inventory
    {
        #region constants
        private const int InventoryMax = 10;
        #endregion

        #region properties
        public Item[] Items { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Inventory()
        {
            this.Items = new Item[InventoryMax];
        }

        public static Inventory Load()
        {
            var inventory = new Inventory();
            return inventory;
        }
        #endregion
    }
}