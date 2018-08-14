using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class Fish
    {
        #region properties
        public string Identifier { get; private set; }

        public string Name { get; private set; }
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

            Name = "";
            Count = 1;
        }
        #endregion
    }
}