using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class SaveDataManager
    {
        public SaveData SaveData { get; private set; }

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SaveDataManager()
        {
        }

        public static SaveDataManager Create()
        {
            return new SaveDataManager();
        }

        public void LoadSaveData()
        {
            SaveData = ES3.Load("SaveData", SaveData.NewData());
        }
        #endregion
    }
}