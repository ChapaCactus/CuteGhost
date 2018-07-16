using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    public class MessageBalloon : MonoBehaviour
    {
        #region constants
        private const string PrefabPath = "Prefabs/UI/MessageBalloon";
        #endregion

        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region properties
        private GameObject speaker { get; set; }
        #endregion

        #region unity callbacks
        private void LateUpdate()
        {
            if(speaker != null)
            {
                var screenPos = Utilities.GetScreenPosition(speaker.transform.position);
                screenPos += new Vector2(0, 50);
                SetLocalPosition(screenPos);
            }
        }
        #endregion

        #region public methods
        public static void Create(Transform parent, Action<MessageBalloon> onCreate)
        {
            var prefab = Resources.Load(PrefabPath) as GameObject;
            var go = Instantiate(prefab, parent);
            var result = go.GetComponent<MessageBalloon>();

            onCreate(result);
        }

        public void SetSpeaker(GameObject speaker)
        {
            this.speaker = speaker;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetLocalPosition(Vector2 pos)
        {
            transform.localPosition = pos;
        }

        public void SetText(string message)
        {
            text.text = message;
        }
        #endregion
    }
}