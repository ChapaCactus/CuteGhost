using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace CCG
{
    public class BattleLog : MonoBehaviour
    {
        #region inner classes
        public struct Setting
        {
            public List<string> messages { get; private set; }

            public Setting(string message)
            {
                this.messages = new List<string>() { message };
            }

            public Setting(List<string> messages)
            {
                this.messages = messages;
            }
        }
        #endregion

        #region constants
        private readonly WaitForSeconds WaitSec = new WaitForSeconds(1);
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region public methods
        public void SetMessage(Setting setting, Action onEnd = null)
        {
            StartCoroutine(SetMessageCoroutine(setting, onEnd));
        }

        /// <summary>
        /// レベルアップ時のメッセージ取得
        /// </summary>
        public static Setting GetBattleLevelupMessage(string charaName, int level)
        {
            var messages = new List<string>()
            {
                $"レベルアップ！！",
                $"{charaName}のレベルが\n{level}になった。",
            };

            return new Setting(messages);
        }

        /// <summary>
        /// 戦闘終了時のメッセージ取得(勝利)
        /// </summary>
        public static Setting GetBattleWinMessage(string charaName, int gainExpAmount)
        {
            var messages = new List<string>()
            {
                "YOU WIN！",
                $"{charaName}は\n{gainExpAmount}のけいけんちをえた。",
            };

            return new Setting(messages);
        }

        /// <summary>
        /// 戦闘終了時のメッセージ取得(敗北)
        /// </summary>
        public static Setting GetBattleLoseMessage(string charaName)
        {
            var messages = new List<string>()
            {
                "YOU LOSE...",
                $"{charaName}は　たおれてしまった...",
            };

            return new Setting(messages);
        }

        /// <summary>
        /// アイテムドロップ時のメッセージ取得
        /// </summary>
        public static Setting GetDropItemMessage(string charaName, string itemName)
        {
            var messages = new List<string>()
            {
                $"{charaName}は\nアイテムをもっていた！",
                $"{itemName}をてにいれた。",
            };

            return new Setting(messages);
        }
        #endregion

        #region private methods
        private IEnumerator SetMessageCoroutine(Setting setting, Action onEnd = null)
        {
            foreach(var message in setting.messages)
            {
                text.text = message;

                yield return WaitSec;
            }

            onEnd.SafeCall();
        }
        #endregion
    }
}