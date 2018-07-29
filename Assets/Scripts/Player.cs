using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Player
    {
        #region inner classes
        public class Status
        {
            public int Level { get; set; }

            public int MaxHealth { get; set; }
            public int Health { get; set; }
        }
        #endregion

        #region properties
        public Status PlayerStatus { get; private set; }
        #endregion

        #region public methods
        public Player(Status status)
        {
            PlayerStatus = status;
        }
        #endregion
    }
}