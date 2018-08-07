using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class FishingController : MonoBehaviour
    {
        #region properties
        private Dictionary<FishingStateType, FishingState> States { get; set; } = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();
        }
        #endregion

        #region private methods
        private void Init()
        {
            States = new Dictionary<FishingStateType, FishingState>()
            {
                {FishingStateType.Start, new FishingStateStart()},
                {FishingStateType.Cast, new FishingStateCast()},
                {FishingStateType.Bite, new FishingStateBite()},
                {FishingStateType.Result, new FishingStateResult()},
                {FishingStateType.End, new FishingStateEnd()},
            };
        }
        #endregion
    }
}