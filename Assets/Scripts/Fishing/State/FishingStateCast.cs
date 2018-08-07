using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class FishingStateCast : FishingState
    {
        #region constants
        private const FishingStateType StateType = FishingStateType.Cast;
        #endregion

        #region public methods
        public override FishingStateType GetStateType()
        {
            return StateType;
        }
        #endregion

        #region private methods
        protected override void OnStart()
        {
        }

        protected override void OnUpdate(float deltaTime)
        {
        }

        protected override void OnEnd()
        {
        }
        #endregion
    }
}