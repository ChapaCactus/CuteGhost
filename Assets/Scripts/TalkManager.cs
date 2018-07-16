using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class TalkManager : SingletonMonoBehaviour<TalkManager>
    {
        #region inner classes
        [Serializable]
        public class Talk
        {
            #region enums
            public enum State
            {
                Start,
                Talking,
                End,
            }
            #endregion

            #region properties
            public bool isTalking { get { return state == State.Start || state == State.Talking; } }

            public int progress { get; private set; }
            public GameObject speaker { get; private set; }
            public State state { get; private set; } = State.End;

            private List<string> messages { get; set; }
            #endregion

            #region public methods
            public Talk(GameObject speaker, TalkMasterRow talkRow)
            {
                this.speaker = speaker;

                messages = new List<string>();
                messages.Add(talkRow._Message);

                progress = 0;

                OnStart();
                OnTalking();
            }

            public void Next()
            {
                if(messages == null)
                {
                    return;
                }

                progress++;

                if (progress >= messages.Count)
                {
                    OnEnd();
                    return;
                }
            }

            public string GetMessage()
            {
                return messages[progress];
            }
            #endregion

            #region private methods
            private void OnStart()
            {
                state = State.Start;

                Ghost.I.SetIsTalking(true);
                UIManager.I.GetBands().FrameIn(true, true);
            }

            private void OnTalking()
            {
                state = State.Talking;
            }

            private void OnEnd()
            {
                state = State.End;

                Ghost.I.SetIsTalking(false);
                UIManager.I.GetBands().FrameOut(true, true);
            }
            #endregion
        }
        #endregion

        #region enums
        #endregion

        #region properties
        private Talk talk { get; set; }

        private MessageBalloon balloon { get; set; }
        private Action onEndTalk { get; set; }
        #endregion

        #region public methods
        public void StartTalk(GameObject speaker, TalkMasterRow talkRow, Action onEndTalk)
        {
            if (talk != null)
            {
                return;
            }

            this.onEndTalk = onEndTalk;

            talk = new Talk(speaker, talkRow);
            RequestCreateMessageBalloon(talk.speaker, balloon =>
            {
                SetBalloon(balloon);
                balloon.SetText(talk.GetMessage());
            });
        }

        public void Next()
        {
            if (balloon != null)
            {
                Destroy(balloon.gameObject);
                balloon = null;
            }

            if (talk != null)
            {
                talk.Next();
                if (talk.state == Talk.State.End)
                {
                    onEndTalk.SafeCall();
                }
            }
        }

        /// <summary>
        /// 吹き出しの生成リクエスト
        /// </summary>
        public void RequestCreateMessageBalloon(GameObject speaker, Action<MessageBalloon> onCreate)
        {
            MessageBalloon.Create(UIManager.I.canvasRect, balloon =>
            {
                balloon.SetSpeaker(speaker);
                onCreate.SafeCall(balloon);
            });
        }

        public bool IsTalking()
        {
            if(talk == null)
            {
                return false;
            }

            return talk.isTalking;
        }
        #endregion

        #region private methods
        private void SetBalloon(MessageBalloon balloon)
        {
            this.balloon = balloon;
        }
        #endregion
    }
}