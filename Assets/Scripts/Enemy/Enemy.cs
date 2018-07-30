using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class Enemy : IFightable
    {
        #region variables
        private CharacterStatus status;
        private Action onDead;
        #endregion

        #region properties
        public CharacterStatus Status { get { return status; } }
        public bool IsDead { get { return Status.IsDead; } }

        public string EnemyID { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Enemy(string enemyID)
        {
            EnemyID = enemyID;

            var row = EnemyMaster.Instance.GetRow(enemyID);
            this.status = new CharacterStatus();
            this.status.SetData(row);
        }

        public void SetOnDead(Action onDead)
        {
            this.onDead = onDead;
        }

        public void Attack(IFightable target)
        {
            target.Damage(Status.ATK);
        }

        public void Damage(int damage)
        {
            Status.Damage(damage);

            if(IsDead)
            {
                onDead.SafeCall();
            }

            Debug.Log($"{Status.Name}は、{damage}を受けた。");
        }
        #endregion
    }
}