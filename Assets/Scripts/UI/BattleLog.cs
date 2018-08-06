using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Threading.Tasks;
using UnityEngine.UI;

namespace CCG
{
    public class BattleLog : MonoBehaviour
    {
        #region inner classes
        public struct LogMessage
        {
            public string head { get; private set; }
            public string body { get; private set; }

            public LogMessage(string head, string body)
            {
                this.head = head;
                this.body = body;
            }
        }
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region public methods
        public void SetMessage(string head, string body = "")
        {
            StartCoroutine(SetMessageCoroutine(head, body));
        }

        public void SetMessage(LogMessage logMessage)
        {
            StartCoroutine(SetMessageCoroutine(logMessage.head, logMessage.body));
        }

        /// <summary>
        /// レベルアップ時のメッセージ取得
        /// </summary>
        public static LogMessage GetBattleLevelupMessage(string charaName, int level)
        {
            var head = $"レベルアップ！！";
            var body = $"{charaName}のレベルが\n{level}になった。";
            return new LogMessage(head, body);
        }

        /// <summary>
        /// 戦闘終了時のメッセージ取得(勝利)
        /// </summary>
        public static LogMessage GetBattleWinMessage(string charaName, int gainExpAmount)
        {
            var head = "YOU WIN！";
            var body = $"{charaName}は\n{gainExpAmount}のけいけんちをえた。";
            return new LogMessage(head, body);
        }

        /// <summary>
        /// 戦闘終了時のメッセージ取得(敗北)
        /// </summary>
        public static LogMessage GetBattleLoseMessage(string charaName)
        {
            var head = "YOU LOSE...";
            var body = $"{charaName}は　たおれてしまった...";
            return new LogMessage(head, body);
        }

        /// <summary>
        /// アイテムドロップ時のメッセージ取得
        /// </summary>
        public static LogMessage GetDropItemMessage(string charaName, string itemName)
        {
            var head = $"{charaName}は\nアイテムをもっていた！";
            var body = $"{itemName}をてにいれた。";
            return new LogMessage(head, body);
        }
        #endregion

        #region private methods
        private IEnumerator SetMessageCoroutine(string head, string body = "")
        {
            text.text = head;

            yield return new WaitForSeconds(0.5f);

            if (!string.IsNullOrEmpty(body))
            {
                text.text = body;
            }
        }
        #endregion
    }
}