using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class FishingBoy : SingletonMonoBehaviour<FishingBoy>
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        [SerializeField]
        private Transform rodPosition = null;
        [SerializeField]
        private Transform floatPosition = null;
        #endregion

        #region properties
        public FishingRod FishingRod { get; private set; }
        public FishingFloat FishingFloat { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
            {
                if(FishingRod.IsCasting)
                {
                    FishingRod.Hook();
                } else
                {
                    FishingRod.Cast(() =>
                    {
                        FishingFloat.OnCast();
                        FishingFloat.gameObject.SetActive(true);
                    });
                }
            }
        }
        #endregion

        #region public methods
        public void Flip(bool isRight)
        {
            spriteRenderer.flipX = !isRight;
        }
        #endregion

        #region private methods
        private void Init()
        {
            FishingRod = FishingRod.Create(rodPosition);
            FishingRod.OnCreate();
            FishingRod.SetOnHookCallback(OnHook);
            FishingFloat = FishingFloat.Create("", floatPosition);
        }

        private void OnHook()
        {
            if(FishingFloat.IsBite())
            {
                GetFish();
            } else
            {
                Debug.Log("魚がかかっていなかった...");
            }

            OnEndFishing();
        }

        private void GetFish()
        {
            Sprite fishSprite = Resources.Load<Sprite>(FishingFloat.Fish.SpritePath);
            UIController.I.Get.Play(fishSprite);

            Debug.Log($"{FishingFloat.Fish.Name}を手に入れた。");
        }

        private void OnEndFishing()
        {
            FishingRod.Finish();
            FishingFloat.Finish();
        }
        #endregion
    }
}