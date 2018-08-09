using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG
{
    public class MessageBalloon : MonoBehaviour
    {
        #region enums
        public enum State
        {
            Wait,
            Playing,
            Complete,
        }
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;

        [SerializeField]
        private Button nextButton = null;
        #endregion

        #region properties
        private Tween Tween { get; set; }
        private State CurrentState { get; set; }

        private Action OnEnd { get; set; }
        #endregion

        #region public methods
        public void Init()
        {
            SetActive(false);
            CurrentState = State.Wait;
            text.text = "";
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(OnClick);
            Tween = null;
            OnEnd = null;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void ShowFullText()
        {
            if (Tween != null)
            {
                Tween.Complete();
            }
        }

        public void Play(string message, Action onEnd)
        {
            OnEnd = onEnd;
            text.text = "";
            CurrentState = State.Playing;

            nextButton.gameObject.SetActive(true);

            var duration = message.Length * 0.1f;
            Tween = text.DOText(message, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
            {
                Tween = null;
                CurrentState = State.Complete;
            });

            SetActive(true);
        }
        #endregion

        #region private methods
        private void OnClick()
        {
            switch (CurrentState)
            {
                case State.Wait:
                    // この時タッチ判定が無いため、ここを通らない想定
                    break;
                case State.Playing:
                    ShowFullText();
                    break;
                case State.Complete:
                    OnEnd.SafeCall();
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}