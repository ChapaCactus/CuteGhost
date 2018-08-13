using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;
using Google2u;

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
            var damage = attacker.Attack;
            Status.Damage(damage);

            BattleUIManager.I.StatusPanel.Setup(Status, Global.Inventory.Gold);

            // ログ表示
            var messages = new List<string>()
            {
                $"{attacker.CharaName}のこうげき！",
                $"{CharaName}に\n{damage}のダメージ！",
            };
            var setting = new BattleLog.Setting(messages);
            BattleUIManager.I.BattleLog.SetMessage(setting);

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

        /// <summary>
        /// レベルアップ
        /// </summary>
        public IEnumerator LevelUp()
        {
            var currentStatus = new CharacterStatus();
            currentStatus.Attack = Status.Attack;
            currentStatus.Defense = Status.Defense;

            // レベルアップ処理
            Status.Level++;
            var statusTableKey = $"Level_{Status.Level.ToString().PadLeft(2, '0')}";
            var statusRow = PlayerStatusTable.Instance.GetRow(statusTableKey);
            Status.UpdateStatus(statusRow);
            // ステータスパネル初期化
            BattleUIManager.I.StatusPanel.Setup(Status, Global.Inventory.Gold);

            var message = BattleLog.GetBattleLevelupMessage(CharaName, Status.Level);
            BattleUIManager.I.BattleLog.SetMessage(message);

            yield return new WaitForSeconds(2f);

            // ステータスアップ表示①
            var messages = new List<string>()
            {
                $"こうげき　が{Status.Attack - currentStatus.Attack}アップ！",
                $"ぼうぎょ　{Status.Defense - currentStatus.Defense}アップ！",
            };
            var setting = new BattleLog.Setting(messages);
            BattleUIManager.I.BattleLog.SetMessage(setting);

            yield return new WaitForSeconds(2f);
        }
        #endregion
    }
}