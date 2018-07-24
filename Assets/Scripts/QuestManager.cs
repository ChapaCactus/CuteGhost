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
        #region properties
        public List<QuestVO> allQuestList { get; private set; }
        public List<QuestVO> offeredQuestList { get; private set; }
        public List<QuestVO> completedQuestList { get; private set; }
        #endregion

        #region public methods
        public void Init()
        {
            allQuestList = LoadAllQuest();
            offeredQuestList = new List<QuestVO>();
            completedQuestList = new List<QuestVO>();
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
        }
        #endregion

        #region private methods
        /// <summary>
        /// 全てのクエストを読み込む
        /// </summary>
        private List<QuestVO> LoadAllQuest()
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
        #endregion
    }
}