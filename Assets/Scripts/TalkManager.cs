using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
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
            public bool IsEnd { get { return state == Talk.State.End; } }

            public List<string> Choises { get; private set; }
            public List<string> Battle { get; private set; }

            public int progress { get; private set; }
            public GameObject speaker { get; private set; }
            public State state { get; private set; } = State.End;

            private List<string> messages { get; set; }
            #endregion

            #region public methods
            public Talk(GameObject speaker, TalkMasterRow talkRow)
            {
                this.speaker = speaker;

                Choises = talkRow._Choises;
                Battle = talkRow._Battle;

                messages = talkRow._Message;

                progress = 0;

                OnStart();
                OnTalking();
            }

            public void Next()
            {
                if (messages == null)
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

                if (!talk.IsEnd)
                {
                    // 終了していなければ、テキスト表示
                    RequestCreateMessageBalloon(talk.speaker, balloon =>
                    {
                        SetBalloon(balloon);
                        balloon.SetText(talk.GetMessage());
                    });
                }
                else
                {
                    // 選択肢が設定されていれば、選択肢を表示
                    if (talk.Choises.Count >= 1
                        && talk.Choises.Any(choise => choise != "None"))
                    {
                        UIManager.I.OpenChoisesPanel(() =>
                        {
                            // YES
                            var yesRow = TalkMaster.Instance.GetRow(talk.Choises[0]);
                            StartTalk(talk.speaker, yesRow, onEndTalk);
                        }, () =>
                        {
                            // NO
                            var noRow = TalkMaster.Instance.GetRow(talk.Choises[1]);
                            StartTalk(talk.speaker, noRow, onEndTalk);
                        });
                        return;
                    }

                    // 戦闘敵が設定されていれば、戦闘シーンに以降
                    if (talk.Battle.Count >= 1
                        && talk.Battle.Any(battle => battle != "None"))
                    {
                        // 戦闘シーンに移動する
                        var enemies = talk.Battle.Select(enemyID => new Enemy(enemyID) as IFightable)
                                                  .ToList();
                        var battleSetting = new BattleManager.BattleSetupData(Global.Player, enemies);
                        Global.BattleManager.StartBattle(battleSetting);

                        return;
                    }

                    OnEnd();
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
            if (talk == null)
            {
                return false;
            }

            return talk.isTalking;
        }
        #endregion

        #region private methods
        private void OnEnd()
        {
            onEndTalk.SafeCall();

            Ghost.I.SetIsTalking(false);
            UIManager.I.GetBands().FrameOut(true, true);
            talk = null;
        }

        private void SetBalloon(MessageBalloon balloon)
        {
            this.balloon = balloon;
        }
        #endregion
    }
}