using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class FishingRod : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        #endregion

        #region properties
        public FishingFloat FishingFloat { get; private set; }

        public bool IsCasting { get; private set; }

        private Action OnHook { get; set; }
        #endregion

        #region public methods
        public static FishingRod Create(Transform parent)
        {
            var prefab = Resources.Load<FishingRod>("Prefabs/FishingBoy/FishingRod");
            var rod = Instantiate(prefab, parent);
            rod.OnCreate();
            return rod;
        }

        public void Finish()
        {
            IsCasting = false;
            gameObject.SetActive(false);
        }

        public void SetOnHookCallback(Action onHook)
        {
            OnHook = onHook;
        }

        public void Cast(Action onFinish)
        {
            IsCasting = true;
            gameObject.SetActive(true);
            onFinish.SafeCall();
        }

        /// <summary>
        /// 引き上げる
        /// </summary>
        public void Hook()
        {
            IsCasting = false;
            OnHook.SafeCall();
        }
        #endregion

        #region private methods
        public void OnCreate()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}