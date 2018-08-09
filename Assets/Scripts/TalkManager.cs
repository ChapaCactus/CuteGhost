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
            public List<string> BattleGroup { get; private set; }

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
                BattleGroup = talkRow._Battle;

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
                MainUIManager.I.GetBands().FrameIn(true, true);
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

        private Action onEndTalk { get; set; }
        #endregion

        #region public methods
        public void StartTalk(GameObject speaker, TalkMasterRow talkRow, Action onEndTalk)
        {
            this.onEndTalk = onEndTalk;

            talk = new Talk(speaker, talkRow);

            var balloon = MainUIManager.I.MessageBalloon;
            balloon.Play(talk.GetMessage(), PlayNext);
        }

        public void PlayNext()
        {
            if (talk == null)
                return;

            // 会話クラスを進めておく
            talk.Next();

            if (!talk.IsEnd)
            {
                MainUIManager.I.MessageBalloon.Play(talk.GetMessage(), PlayNext);
            }
            else
            {
                // 選択肢が設定されていれば、選択肢を表示
                if (talk.Choises.Count >= 1
                    && talk.Choises.Any(choise => choise != "None"))
                {
                    MainUIManager.I.OpenChoisesPanel(() =>
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
                if (talk.BattleGroup.Count >= 1
                    && talk.BattleGroup.Any(battle => battle != "None"))
                {
                    var battleGroupID = talk.BattleGroup
                                            .OrderBy(n => Guid.NewGuid())
                                            .First();
                    var battleGroup = EnemyGroupMaster.Instance.GetRow(battleGroupID);
                    var enemies = new List<IFightable>()
                        {
                            (string.IsNullOrEmpty(battleGroup._Enemy1) ? Enemy.Empty() : new Enemy(battleGroup._Enemy1)),
                            (string.IsNullOrEmpty(battleGroup._Enemy2) ? Enemy.Empty() : new Enemy(battleGroup._Enemy2)),
                            (string.IsNullOrEmpty(battleGroup._Enemy3) ? Enemy.Empty() : new Enemy(battleGroup._Enemy3)),
                        };

                    var battleSetting = new BattleManager.BattleSetupData(Global.Player, enemies, battleGroup._Background);
                    Global.BattleManager.StartBattle(battleSetting);

                    return;
                }

                OnEnd();
            }
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
            MainUIManager.I.GetBands().FrameOut(true, true);
            MainUIManager.I.MessageBalloon.SetActive(false);
            MainUIManager.I.MessageBalloon.Init();
            talk = null;
        }
        #endregion
    }
}