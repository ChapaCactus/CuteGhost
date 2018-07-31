﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;

namespace CCG
{
    public class Player : IFightable
    {
        #region variables
        private CharacterStatus status;
        #endregion

        #region properties
        public CharacterStatus Status { get { return status; } }
        public bool IsDead { get { return Status.IsDead; } }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>¥
        public Player(CharacterStatus status)
        {
            this.status = status;
        }

        public void Attack(IFightable target)
        {
            // 射撃音再生
            MasterAudio.PlaySound("Blaster_001");

            target.Damage(Status.ATK);
        }

        public void Damage(int damage)
        {
            Status.Damage(damage);

            Debug.Log($"{Status.Name}は、{damage}を受けた。");
        }
        #endregion
    }
}