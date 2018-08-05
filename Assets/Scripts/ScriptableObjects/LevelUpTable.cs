using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [Serializable]
    public struct LevelUpSetting
    {
        public int Level;
        public int Total;// そのレベルへの閾値
    }

    [CreateAssetMenu(menuName = "ScriptableObject/LevelupTable")]
    public class LevelUpTable : ScriptableObject
    {
        #region variables
        [SerializeField]
        private List<LevelUpSetting> settings = new List<LevelUpSetting>();
        #endregion

        #region properties
        public List<LevelUpSetting> Settings { get { return settings; } }
        #endregion
    }
}