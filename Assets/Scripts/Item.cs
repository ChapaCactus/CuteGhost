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
        public Item(ItemMasterRow masterData)
        {
            this.Name = masterData._Name;
            this.Price = masterData._Price;
        }
        #endregion
    }
}