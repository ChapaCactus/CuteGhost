using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;
using Google2u;

namespace CCG
{
    public class NPC : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private QuestMaster.rowIds questId = QuestMaster.rowIds.ID_001;
        #endregion

        #region unity callback
        #endregion

        #region public methods
        public void Talk(Action onEndTalk)
        {
            var questRow = QuestMaster.Instance.GetRow(questId);
            var talkId = questRow._Talk;
            var talkRow = TalkMaster.Instance.GetRow(talkId);

            TalkManager.I.StartTalk(gameObject, talkRow, onEndTalk);
        }
        #endregion

        #region private methods
        #endregion
    }
}