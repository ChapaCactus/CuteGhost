using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;
using System.Linq;

namespace CCG
{
    public class QuestManager
    {
        #region constants
        private const string OfferedQuestListSaveKey = "OfferedQuestList";
        private const string CompletedQuestListSaveKey = "CompletedQuestList";
        #endregion

        #region properties
        public List<QuestVO> allQuestList { get; private set; }
        public List<QuestVO> offeredQuestList { get; private set; }
        public List<QuestVO> completedQuestList { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QuestManager()
        {
            allQuestList = LoadAllQuestFromMaster();

            Load();
        }

        public static QuestManager Create()
        {
            return new QuestManager();
        }

        /// <summary>
        /// 受領済みクエストか調べる
        /// </summary>
        public bool CheckIsOfferedQuest(string id)
        {
            return offeredQuestList.Any(offered => offered.id == id);
        }

        /// <summary>
        /// クエストを受領
        /// </summary>
        public void OfferQuest(string rowId)
        {
            if(offeredQuestList == null)
            {
                offeredQuestList = new List<QuestVO>();
            }

            var isOffered = offeredQuestList.Any(offered => offered.id == rowId);
            if (isOffered)
            {
                Debug.Log("既に受領しているクエストです");
                return;
            }
            
            var vo = QuestVO.Create(rowId);
            offeredQuestList.Add(vo);

            Debug.Log($"Offered Quest {rowId}");

            Save();
        }
        #endregion

        #region private methods
        /// <summary>
        /// 全てのクエストを読み込む
        /// </summary>
        private List<QuestVO> LoadAllQuestFromMaster()
        {
            var idValues = Enum.GetValues(typeof(QuestMaster.rowIds))
                               .Cast<QuestMaster.rowIds>()
                               .ToList();

            return idValues.Select(id => QuestVO.Create(id.ToString()))
                                .ToList();
        }

        private void CompleteQuest(string id)
        {
            bool alreadyCompleted = completedQuestList.Any(completed => completed.id == id);
            if(alreadyCompleted)
            {
                return;
            }

            bool isOffered = offeredQuestList.Any(offered => offered.id == id);
            if(isOffered)
            {
                
            }
        }

        private void Save()
        {
            var offeredIdList = offeredQuestList.Select(quest => quest.id)
                                                .ToList();
            var completedIdList = completedQuestList.Select(quest => quest.id)
                                                    .ToList();
            
            ES3.Save<List<string>>(OfferedQuestListSaveKey, offeredIdList);
            ES3.Save<List<string>>(CompletedQuestListSaveKey, completedIdList);
        }

        private void Load()
        {
            var offeredIdList = ES3.Load<List<string>>(OfferedQuestListSaveKey
                                                                   , defaultValue: new List<string>());
            var completedIdList = ES3.Load<List<string>>(CompletedQuestListSaveKey
                                                                     , defaultValue: new List<string>());

            offeredQuestList = offeredIdList.Select(id => QuestVO.Create(id))
                                            .ToList();
            completedQuestList = completedIdList.Select(id => QuestVO.Create(id))
                                                .ToList();
        }
        #endregion
    }
}