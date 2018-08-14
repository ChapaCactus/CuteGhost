using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class FishingBoy : MonoBehaviour
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
                FishingRod.Cast(() => 
                {
                    FishingFloat.OnCast();
                    FishingFloat.gameObject.SetActive(true);
                });
            }
        }
        #endregion

        #region public methods
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
            FishingRod.gameObject.SetActive(false);
            FishingFloat.gameObject.SetActive(false);

            if(FishingFloat.IsBite())
            {
                GetFish();
            }
        }

        private void GetFish()
        {
        }
        #endregion
    }
}