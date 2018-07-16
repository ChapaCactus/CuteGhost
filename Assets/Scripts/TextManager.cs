using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class TextManager : SingletonMonoBehaviour<TextManager>
    {
        #region public methods
        /// <summary>
        /// 吹き出しの生成リクエスト
        /// </summary>
        public void RequestCreateMessageBalloon(GameObject speaker, Action<MessageBalloon> onCreate)
        {
            MessageBalloon.Create(UIManager.I.canvasRect, balloon => 
            {
                // 座標を発言者に合わせて返す
                var screenPos = Utilities.GetScreenPosition(speaker.transform.position);
                balloon.SetLocalPosition(screenPos);

                onCreate(balloon);
            });
        }
        #endregion
    }
}