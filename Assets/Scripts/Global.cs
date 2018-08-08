using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using Google2u;

namespace CCG
{
    public static class Global
    {
        #region properties
        public static bool IsGameInitialized { get; private set; } = false;

        public static Player Player { get; private set; }
        public static Inventory Inventory { get; private set; }

        public static SaveDataManager SaveDataManager { get; private set; }
        public static BattleManager BattleManager { get; private set; }
        public static QuestManager QuestManager { get; private set; }

        public static IInsightable InsightTarget { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            // セーブデータマネージャ初期化、セーブデータロード
            SaveDataManager = SaveDataManager.Create();
            SaveDataManager.Load();
            // プレイヤクラス初期化
            Player = LoadPlayerData();
            // インベントリ初期化
            Inventory = Inventory.Load();

            BattleManager = BattleManager.Create();
            QuestManager = QuestManager.Create();

            SetInsightTarget(null);

            IsGameInitialized = true;
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
            var saveData = Global.SaveDataManager.SaveData;

            var status = new CharacterStatus();
            status.CharaName = saveData.name;
            status.Level = saveData.level;

            var statusTableKey = $"Level_{status.Level.ToString().PadLeft(2, '0')}";
            var statusTable = PlayerStatusTable.Instance.GetRow(statusTableKey);
            status.UpdateStatus(statusTable);

            var player = new Player(status);

            return player;
        }
        #endregion
    }
}