﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class Item
    {
        #region properties
        public string MasterID { get; private set; }

        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Type { get; private set; }
        public int Value { get; private set; }
        public string Description { get; private set; }

        public bool IsEmpty { get { return Name == "Empty"; } }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Item(ItemMaster.rowIds id)
        {
            MasterID = id.ToString();
            var row = ItemMaster.Instance.GetRow(id);
            SetData(row);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Item(string id)
        {
            MasterID = id;
            var row = ItemMaster.Instance.GetRow(id);
            SetData(row);
        }

        public void SetData(ItemMasterRow row)
        {
            this.Name = row._Name;
            this.Price = row._Price;
            this.Type = row._Type;
            this.Value = row._Value;
            this.Description = row._Description;
        }

        public void Use()
        {
            switch(Type)
            {
                case "Food":
                    Global.Player.Cure(Value);
                    break;

                default:
                    break;
            }
        }

        public static Item Empty()
        {
            return new Item(ItemMaster.rowIds.Empty);
        }
        #endregion
    }
}