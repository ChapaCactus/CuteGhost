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
        private void Awake()
        {
        }
        #endregion

        #region public methods
        public void Talk()
        {
            var row = QuestMaster.Instance.GetRow(questId);
            var message = row._Description;

            TextManager.I.RequestCreateMessageBalloon(gameObject, balloon =>
            {
                balloon.SetText(message);
            });
        }
        #endregion
    }
}