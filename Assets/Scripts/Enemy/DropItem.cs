using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class DropItem
    {
        #region properties
        public Item Item { get; private set; }
        public int DropRate { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        public DropItem(Item item, string dropRate)
        {
            this.Item = item;

            var dropValue = dropRate.Replace("%", "");
            this.DropRate = int.Parse(dropValue);
        }
        #endregion
    }
}