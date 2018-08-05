using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [CreateAssetMenu(menuName = "ScriptableObject/SpriteSetting")]
    public class SpriteSetting : ScriptableObject
    {
        #region variables
        [SerializeField]
        private List<Sprite> idleSprites = new List<Sprite>();
        #endregion

        #region properties
        public List<Sprite> IdleSprites { get { return idleSprites; } }
        #endregion
    }
}