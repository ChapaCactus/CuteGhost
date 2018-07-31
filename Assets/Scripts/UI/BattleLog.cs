using System;
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
        public async void SetMessage(string head, string body = "")
        {
            text.text = head;

            await Task.Delay(500);

            if (!string.IsNullOrEmpty(body))
            {
                text.text = body;
            }
        }
        #endregion
    }
}