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
        private const int InventoryMax = 20;
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
            this.Items = new Item[InventoryMax]
                .ToList()
                .Select(_ => Item.Empty())
                .ToArray();
        }

        public static Inventory Load()
        {
            var inventory = new Inventory();
            return inventory;
        }

        /// <summary>
        /// アイテム追加
        /// </summary>
        public void AddItem(Item item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if(Items[i].IsEmpty)
                {
                    Items[i] = item;
                    break;
                }
            }
        }
        #endregion
    }
}