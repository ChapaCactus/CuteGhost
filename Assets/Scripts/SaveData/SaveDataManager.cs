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

        public void Save()
        {
            var saving = new SaveData();
            saving.name = Global.Player.CharaName;
            saving.level = Global.Player.Status.Level;
            saving.exp = Global.Player.Status.Exp;

            ES3.Save<SaveData>("SaveData", saving);
        }

        public void Load()
        {
            SaveData = ES3.Load("SaveData", SaveData.NewData());
        }
        #endregion
    }
}