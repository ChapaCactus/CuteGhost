using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class SaveDataManager
    {
        #region public methods
        public SaveData Load()
        {
            return new SaveData();
        }

        public void Save()
        {
        }

        public void DeleteSaveData()
        {
        }
        #endregion
    }
}