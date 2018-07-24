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
        #region inner classes
        [Serializable]
        public class View
        {
            [SerializeField]
            private Transform markPosition = null;

            public SpriteRenderer mark { get; private set; }

            public void SetMark(SpriteRenderer mark)
            {
                this.mark = mark;

                this.mark.transform.SetParent(markPosition, false);
                this.mark.transform.localPosition = Vector2.zero;
            }

            public void ShowMark(bool isShow)
            {
                Assert.IsNotNull(mark);
                if(mark == null)
                {
                    return;
                }

                mark.enabled = isShow;
            }
        }
        #endregion

        #region variables
        [SerializeField]
        private QuestMaster.rowIds questId = QuestMaster.rowIds.ID_001;

        [SerializeField]
        private View view = new View();
        #endregion

        #region properties
        #endregion

        #region unity callback
        private void Awake()
        {
            // マークセット&初期化
            var prefab = Resources.Load("Prefabs/Effect/ExclamationMark") as GameObject;
            var mark = Instantiate(prefab, null).GetComponent<SpriteRenderer>();
            view.SetMark(mark);
            view.ShowMark(false);
        }
        #endregion

        #region public methods
        public void Talk()
        {
            var questRow = QuestMaster.Instance.GetRow(questId);
            var talkId = questRow._Talk;
            var talkRow = TalkMaster.Instance.GetRow(talkId);

            TalkManager.I.StartTalk(gameObject, talkRow, OnEndTalk);
        }

        public void ShowMark(bool isShow)
        {
            view.ShowMark(isShow);
        }
        #endregion

        #region private methods
        private void OnEndTalk()
        {
            var questRow = QuestMaster.Instance.GetRow(questId);

            // クエスト受領
            Global.questManager.OfferQuest(questId);

            // 受領アナウンス再生
            var questTitle = questRow._Name;
            var questTitleCombine = $"クエスト「{questTitle}」\nを受領した。";
            UIManager.I.ShowAnnounceMessage(questTitleCombine);
        }
        #endregion
    }
}