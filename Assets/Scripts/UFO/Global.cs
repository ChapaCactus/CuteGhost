using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public static class Global
    {
        #region properties
        public static GameData GameData { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            GameData = new GameData();
        }
        #endregion
    }
}