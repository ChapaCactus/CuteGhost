using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;
using Google2u;

namespace CCG
{
    public class NPC : MonoBehaviour, IInsightable
    {
        #region variables
        [SerializeField]
        private NPCMaster.rowIds id = NPCMaster.rowIds.ID_001;

        [SerializeField]
        private Transform markPosition = null;

        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        [SerializeField]
        private SpriteSetting spriteSetting = null;
        #endregion

        #region properties
        public string Name { get { return MasterData._Name; } }
        public string QuestID { get { return MasterData._Quest; } }

        public SpriteRenderer Mark { get; private set; }

        private NPCMasterRow MasterData { get; set; }
        // アニメーション
        private Coroutine Animation { get; set; } = null;
        #endregion

        #region unity callback
        private void Awake()
        {
            MasterData = NPCMaster.Instance.GetRow(id);

            // マークセット&初期化
            var prefab = Resources.Load("Prefabs/Effect/ExclamationMark") as GameObject;
            var mark = Instantiate(prefab, null).GetComponent<SpriteRenderer>();
            SetMark(mark);
            ShowMark(false);

            // GameObject名変更
            gameObject.name = $"NPC [{Name}]";
        }

        private void Start()
        {
            // Idleアニメーションを再生しておく
            PlayIdleAnimation();
        }
        #endregion

        #region public methods
        public void Action()
        {
            Talk();
        }

        public void OnInsightEnter()
        {
            ShowMark(true);
        }

        public void OnInsightExit()
        {
            ShowMark(false);
        }

        public void Talk()
        {
            var isQuestOffered = Global.questManager.CheckIsOfferedQuest(QuestID);
            // 受領済状態の会話 or 未受領状態の会話IDを取得
            var talkID = isQuestOffered ? MasterData._OfferedTalk : MasterData._NotOfferTalk;
            var talkRow = TalkMaster.Instance.GetRow(talkID);
            // 会話開始
            TalkManager.I.StartTalk(gameObject, talkRow, OnEndTalk);
        }

        public void SetMark(SpriteRenderer mark)
        {
            Mark = mark;

            Mark.transform.SetParent(markPosition, false);
            Mark.transform.localPosition = Vector2.zero;
        }

        public void ShowMark(bool isShow)
        {
            Assert.IsNotNull(Mark);
            if (Mark == null)
            {
                return;
            }

            Mark.enabled = isShow;
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        #endregion

        #region private methods
        private void OnEndTalk()
        {
            if(QuestID == "None")
            {
                // クエストを所持していないNPCなら何もしない
                return;
            }

            // クエストを受けていなければ受領
            var isQuestOffered = Global.questManager.CheckIsOfferedQuest(QuestID);
            if (!isQuestOffered)
            {
                // クエスト受領
                Global.questManager.OfferQuest(QuestID);

                // 受領アナウンス再生
                var questRow = QuestMaster.Instance.GetRow(QuestID);
                var questTitle = questRow._Name;
                var questTitleCombine = $"クエスト「{questTitle}」\nをうけた";
                UIManager.I.ShowAnnounceMessage(questTitleCombine, 1.5f);
            }
            else
            {
                // 既にクエストを受けていれば何もしない
                // TODO クエストクリアチェック？
                // TODO クエスト詳細を開く？
            }
        }

        private void PlayIdleAnimation()
        {
            if (Animation != null)
            {
                StopCoroutine(Animation);
            }

            Animation = StartCoroutine(AnimationLoop(spriteSetting.IdleSprites));
        }

        private IEnumerator AnimationLoop(List<Sprite> sprites)
        {
            var span = new WaitForSeconds(0.3f);
            var playIndex = 0;

            while (true)
            {
                var sprite = sprites[playIndex];
                SetSprite(sprite);

                playIndex++;
                if (playIndex >= sprites.Count)
                {
                    playIndex = 0;
                }

                yield return span;
            }
        }
        #endregion
    }
}