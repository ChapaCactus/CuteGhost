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
        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region public methods
        public void SetMessage(string head, string body = "")
        {
            StartCoroutine(SetMessageCoroutine(head, body));
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