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
        private Text text;
        #endregion

        #region public methods
        public static void Create(Transform parent, Action<MessageBalloon> onCreate)
        {
            var prefab = Resources.Load(PrefabPath) as GameObject;
            var go = Instantiate(prefab, parent);
            var result = go.GetComponent<MessageBalloon>();

            onCreate(result);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void SetText(string message)
        {
            text.text = message;
        }
        #endregion
    }
}