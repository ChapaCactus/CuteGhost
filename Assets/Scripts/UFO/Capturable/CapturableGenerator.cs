using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    /// <summary>
    /// 捕獲可能なキャラを生成する
    /// </summary>
    public class CapturableGenerator : SingletonMonoBehaviour<CapturableGenerator>
    {
        #region constants
        private const float TIME_SPAN = 1.8f;
        #endregion

        #region variables
        [SerializeField]
        private List<Transform> generatePositions = new List<Transform>();
        #endregion

        #region properties
        private bool IsRunning { get; set; } = false;
        private float Timer { get; set; } = TIME_SPAN;
        #endregion

        #region unity callbacks
        private void Update()
        {
            if (!IsRunning)
                return;

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Timer = TIME_SPAN;
                Create();
            }
        }
        #endregion

        #region public methods
        public void StartTimer() => IsRunning = true;
        public void StopTimer() => IsRunning = false;
        #endregion

        #region private methods
        private void Create()
        {
            PoolingManager.I.Pick("Man", poolable =>
            {
                poolable.Pick();
            });
        }
        #endregion
    }
}