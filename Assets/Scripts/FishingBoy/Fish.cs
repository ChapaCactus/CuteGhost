using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG.FishingBoy
{
    public class Fish
    {
        #region constants
        private const string PathHeader = "Sprites/FishingBoy/Fish";
        #endregion

        #region properties
        public string Identifier { get; private set; }

        public string Name { get; private set; }
        public float BiteTime { get; private set; }

        public string SpriteFileName { get; private set; }
        public string SpritePath { get { return $"{PathHeader}/{SpriteFileName}"; }}

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
            SpriteFileName = row._Sprite;

            Count = 1;
        }
        #endregion
    }
}