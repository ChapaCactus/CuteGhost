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
        public static bool IsGameInitialized { get; private set; } = false;

        public static Player Player { get; private set; }
        public static Inventory Inventory { get; private set; }

        public static BattleManager BattleManager { get; private set; }
        public static QuestManager QuestManager { get; private set; }

        public static IInsightable InsightTarget { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            Player = LoadPlayerData();
            Inventory = Inventory.Load();

            BattleManager = BattleManager.Create();
            QuestManager = QuestManager.Create();

            SetInsightTarget(null);

            IsGameInitialized = true;
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

        #region private methods
        private static Player LoadPlayerData()
        {
            var status = new CharacterStatus();
            status.CharaName = "あなた";
            status.Level = 1;
            status.Exp = 0;
            status.MaxHealth = 10;
            status.Health = 10;
            status.ATK = 400;
            var player = new Player(status);

            return player;
        }
        #endregion
    }
}