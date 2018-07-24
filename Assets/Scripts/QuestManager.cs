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
        public void Init()
        {
            allQuestList = LoadAllQuestFromMaster();

            Load();
        }

        /// <summary>
        /// クエストを受領
        /// </summary>
        public void OfferQuest(QuestMaster.rowIds rowId)
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

            return idValues.Select(id => QuestVO.Create(id))
                                .ToList();
        }

        private void CompleteQuest(QuestMaster.rowIds id)
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
            
            ES3.Save<List<QuestMaster.rowIds>>(OfferedQuestListSaveKey, offeredIdList);
            ES3.Save<List<QuestMaster.rowIds>>(CompletedQuestListSaveKey, completedIdList);
        }

        private void Load()
        {
            var offeredIdList = ES3.Load<List<QuestMaster.rowIds>>(OfferedQuestListSaveKey
                                                                   , defaultValue: new List<QuestMaster.rowIds>());
            var completedIdList = ES3.Load<List<QuestMaster.rowIds>>(CompletedQuestListSaveKey
                                                                     , defaultValue: new List<QuestMaster.rowIds>());

            offeredQuestList = offeredIdList.Select(id => QuestVO.Create(id))
                                            .ToList();
            completedQuestList = completedIdList.Select(id => QuestVO.Create(id))
                                                .ToList();
        }
        #endregion
    }
}