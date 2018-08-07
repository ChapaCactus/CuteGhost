using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public enum FishingStateType
    {
        Start,

        Cast,
        Bite,
        Result,

        End,
    }

    public abstract class FishingState
    {
        #region public methods
        public void Start()
        {
            OnStart();
        }

        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        public void End()
        {
            OnEnd();
        }

        public abstract FishingStateType GetStateType();
        #endregion

        #region private methods
        protected abstract void OnStart();
        protected abstract void OnUpdate(float deltaTime);
        protected abstract void OnEnd();
        #endregion
    }
}