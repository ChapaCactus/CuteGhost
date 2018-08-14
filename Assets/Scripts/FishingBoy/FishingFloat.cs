using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class FishingFloat : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        #endregion

        #region properties
        public Fish Fish { get; private set; }
        #endregion

        #region public methods
        public static FishingFloat Create(string identifier, Transform parent)
        {
            var prefab = Resources.Load<FishingFloat>("Prefabs/FishingBoy/FishingFloat");
            var fishingFloat = Instantiate(prefab, parent);
            fishingFloat.OnCreate();
            return fishingFloat;
        }

        public void OnCast()
        {
        }

        public bool IsBite()
        {
            return true;
        }
        #endregion

        #region private methods
        private void OnCreate()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}