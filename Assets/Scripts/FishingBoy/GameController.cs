using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG.FishingBoy
{
    public class GameController : SingletonMonoBehaviour<GameController>
    {
        #region enums
        public enum GameState
        {
            Fishing,
            Shop,
        }
        #endregion

        #region variables
        [SerializeField]
        private Transform cameraTarget = null;
        #endregion

        #region properties
        public GameState CurrentGameState { get; private set; }

        public bool IsStateChanging { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();

            Assert.IsNotNull(cameraTarget);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                ChangeState(GameState.Shop);
                return;
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                ChangeState(GameState.Fishing);
                return;
            }
        }
        #endregion

        #region public methods
        public void ChangeState(GameState next)
        {
            if (IsStateChanging)
                return;
            if (CurrentGameState == next)
                return;
            CurrentGameState = next;

            OnChangeState();
        }
        #endregion

        #region private methods
        private void Init()
        {
            ShopBob.I.SetActive(false);
        }

        private void OnChangeState()
        {
            switch (CurrentGameState)
            {
                case GameState.Fishing:
                    OnChangeFishingState();
                    break;
                case GameState.Shop:
                    OnChangeShopState();
                    break;
            }
        }

        private void OnChangeFishingState()
        {
            IsStateChanging = true;
            ShopBob.I.SetActive(false);
            FishingBoy.I.Flip(false);
            cameraTarget.DOMoveX(0, 1)
                  .OnComplete(() => 
            {
                IsStateChanging = false;
            });
        }

        private void OnChangeShopState()
        {
            IsStateChanging = true;
            ShopBob.I.SetActive(true);
            FishingBoy.I.Flip(true);
            cameraTarget.DOMoveX(1.2f, 1)
                  .OnComplete(() => 
            {
                IsStateChanging = false;
            });
        }
        #endregion
    }
}