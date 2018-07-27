using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public static class Global
    {
        #region properties
        public static QuestManager questManager { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            questManager = new QuestManager();
            questManager.Init();
        }

        public static void StartGame()
        {
        }

        /// <summary>
        /// 全セーブデータ削除
        /// </summary>
        public static void DeleteAllSaveData()
        {
            //var keys = ES3.GetKeys()
            //              .ToList();
            //keys.ForEach(key => ES3.DeleteKey(key));

            Debug.Log("全セーブデータを削除しました。");
        }
        #endregion
    }
}