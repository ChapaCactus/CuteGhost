using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class Enemy : IFightable
    {
        #region constants
        private const string EmptyKey = "Empty";
        #endregion

        #region variables
        private CharacterStatus status;
        private Action onDead;
        #endregion

        #region properties
        public CharacterStatus Status { get { return status; } }
        public string CharaName { get { return Status.CharaName; } }
        public bool IsDead { get { return Status.IsDead; } }

        public DropItem DropItem { get; private set; }

        public bool IsEmpty { get { return Status.CharaName == EmptyKey; } }
        public string EnemyID { get; private set; }
        public string SpritePath { get; private set; }
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
            this.SpritePath = row._Sprite;

            if (row._DropItem != null
                && row._DropItem.Count > 0)
            {
                var dropItem = new Item(row._DropItem[0]);
                var dropRate = row._DropItem[1];
                this.DropItem = new DropItem(dropItem, dropRate);
            }
        }

        public static Enemy Empty()
        {
            var empty = new Enemy(EmptyKey);
            return empty;
        }

        public void SetOnDead(Action onDead)
        {
            this.onDead = onDead;
        }

        public void Attack(IFightable target)
        {
            target.Damage(Status);
        }

        public void Damage(CharacterStatus attacker)
        {
            var damage = attacker.Attack;
            Status.Damage(damage);

            if (IsDead)
            {
                onDead.SafeCall();
            }

            // ログ表示
            var head = $"{attacker.CharaName}のこうげき！";
            var body = $"{CharaName}に\n{damage}のダメージ！";
            BattleUIManager.I.BattleLog.SetMessage(head, body);
        }
        #endregion
    }
}