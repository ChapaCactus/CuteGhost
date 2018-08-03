using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Inventory
    {
        #region properties
        public List<Item> Items { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Inventory()
        {
            this.Items = new List<Item>();
        }

        public static Inventory Load()
        {
            return new Inventory();
        }
        #endregion
    }
}