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

        public void Cure(int cure)
        {
            Status.Cure(cure);
        }

        /// <summary>
        /// 経験値取得
        /// </summary>
        /// <returns><c>true</c>, レベルアップした, <c>false</c> レベルアップしていない</returns>
        /// <param name="gainExp">取得経験値</param>
        public bool GainExp(int gainExp)
        {
            Status.Exp += gainExp;

            int nextLevel = (Status.Level + 1);
            int nextExp = Global.BattleManager
                                .ExpTable.GetExpFromLevel(ExpTable.CharacterType.Player, nextLevel);// 次レベルの必要経験値を取得
            bool isLevelup = (Status.Exp >= nextExp);
            return isLevelup;
        }
        #endregion
    }
}