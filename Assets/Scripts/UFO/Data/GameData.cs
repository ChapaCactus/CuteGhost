using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public class GameData
    {
        #region properties
        public int Coin { get; private set; }
        public int GoldCoin { get; private set; }
        #endregion

        #region public methods
        public void AddSilverCoin(int add)
        {
            Coin += add;
            UIManager.I.OnUpdateCoin();
        }

        public void AddGoldCoin(int add)
        {
            GoldCoin += add;
            UIManager.I.OnUpdateCoin();
        }
        #endregion
    }
}