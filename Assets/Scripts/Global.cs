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

        public static IInsightable InsightTarget { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            questManager = new QuestManager();
            questManager.Init();

            SetInsightTarget(null);
        }

        public static void StartGame()
        {
        }

        public static void SetInsightTarget(IInsightable insighted)
        {
            InsightTarget = insighted;
        }

        /// <summary>
        /// 全セーブデータ削除
        /// </summary>
        public static void DeleteAllSaveData()
        {
            var keys = ES3.GetKeys()
                          .ToList();
            keys.ForEach(key => ES3.DeleteKey(key));

            UIManager.I.ShowAnnounceMessage("全セーブデータを削除\nしました。(再起動後有効)", 2);
        }
        #endregion
    }
}