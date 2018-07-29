using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Player
    {
        #region variables
        private CharacterStatus status;
        #endregion

        #region properties
        public CharacterStatus Status { get { return status; } }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>¥
        public Player(CharacterStatus status)
        {
            this.status = status;
        }
        #endregion
    }
}