using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class FishingBoyManager
    {
        #region properties
        public SaveDataManager SaveDataManager { get; private set; }
        #endregion

        #region public methods
        public void Init()
        {
            SaveDataManager = new SaveDataManager();
            SaveDataManager.Load();
        }
        #endregion

        #region private methods
        #endregion
    }
}