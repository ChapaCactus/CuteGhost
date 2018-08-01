using System;
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
        public string CharaName { get { return Status.CharaName; } }

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

        public void UpdateStatus(CharacterStatus status)
        {
            this.status = status;
        }

        public void Attack(IFightable target)
        {
            // 射撃音再生
            MasterAudio.PlaySound("Blaster_001");

            target.Damage(Status);
        }

        public void Damage(CharacterStatus attacker)
        {
            var damage = attacker.ATK;
            Status.Damage(damage);

            BattleUIManager.I.StatusPanel.Setup(Status);

            // ログ表示
            var head = $"{attacker.CharaName}のこうげき！";
            var body = $"{CharaName}に\n{damage}のダメージ！";
            BattleUIManager.I.BattleLog.SetMessage(head, body);

            MainCamera.I.Shake();
        }
        #endregion
    }
}