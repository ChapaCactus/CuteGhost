using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG.FishingBoy
{
    public class Fish
    {
        #region properties
        public string Identifier { get; private set; }

        public string Name { get; private set; }
        public float BiteTime { get; private set; }

        public int Count { get; private set; }

        public int Price { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Fish(string identifier)
        {
            Identifier = identifier;

            var row = FishMaster.Instance.GetRow(identifier);
            Name = row._Name;
            BiteTime = row._BiteTime;

            Count = 1;
        }
        #endregion
    }
}