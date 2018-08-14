using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG.FishingBoy
{
    public class FishingFloat : MonoBehaviour
    {
        #region enums
        public enum State
        {
            None,// 状態なし
            Floating,// 浮いている
            Biting,// 魚が食らいついている
            Away,// 魚が逃げた
        }
        #endregion

        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        [SerializeField]
        private Sprite waitSprite = null;
        [SerializeField]
        private Sprite bitingSprite = null;
        #endregion

        #region properties
        public Fish Fish { get; private set; }

        public State CurrentState { get; private set; }

        public float FloatTimer { get; private set; }// 浮いている時間、終了後食いつく
        public float BiteTimer { get; private set; }// 噛み付いている時間、終了後逃げる
        #endregion

        #region unity callbacks
        private void Update()
        {
            switch (CurrentState)
            {
                case State.Floating:
                    if (FloatTimer > 0)
                    {
                        FloatTimer -= Time.deltaTime;
                        if (FloatTimer <= 0)
                        {
                            FloatTimer = 0;
                            OnBite();
                        }
                    }
                    break;
                case State.Biting:
                    if (BiteTimer > 0)
                    {
                        BiteTimer -= Time.deltaTime;
                        if (BiteTimer <= 0)
                        {
                            BiteTimer = 0;
                            OnAway();
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region public methods
        public static FishingFloat Create(string identifier, Transform parent)
        {
            var prefab = Resources.Load<FishingFloat>("Prefabs/FishingBoy/FishingFloat");
            var fishingFloat = Instantiate(prefab, parent);
            fishingFloat.OnCreate();
            return fishingFloat;
        }

        public void Finish()
        {
            CurrentState = State.None;
            gameObject.SetActive(false);
        }

        public void OnCast()
        {
            Fish = new Fish($"{FishMaster.rowIds.Small}");
            FloatTimer = 3;// 仮
            BiteTimer = Fish.BiteTime;
            OnFloating();
        }

        public bool IsBite()
        {
            return CurrentState == State.Biting;
        }
        #endregion

        #region private methods
        private void OnCreate()
        {
            gameObject.SetActive(false);
        }

        private void OnFloating()
        {
            CurrentState = State.Floating;
            spriteRenderer.sprite = waitSprite;
        }

        private void OnBite()
        {
            CurrentState = State.Biting;
            spriteRenderer.sprite = bitingSprite;

            Debug.Log($"{Fish.Name}が食らいついた。");
        }

        private void OnAway()
        {
            CurrentState = State.Away;
            spriteRenderer.sprite = waitSprite;

            Debug.Log($"{Fish.Name}が逃げた。。。");
        }
        #endregion
    }
}