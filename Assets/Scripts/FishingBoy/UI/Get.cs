using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Collections;

namespace CCG
{
    public class Get : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer rendererG = null;
        [SerializeField]
        private SpriteRenderer rendererE = null;
        [SerializeField]
        private SpriteRenderer rendererT = null;

        [SerializeField]
        private SpriteRenderer fishRenderer = null;
        #endregion

        #region public methods
        public void SetActive(bool isActive)
        {
            rendererG.enabled = isActive;
            rendererE.enabled = isActive;
            rendererT.enabled = isActive;
            fishRenderer.enabled = isActive;
        }

        public void Play(Sprite fishSprite)
        {
            StartCoroutine(PlayCoroutine(fishSprite));
        }
        #endregion

        #region private methods
        private IEnumerator PlayCoroutine(Sprite fishSprite)
        {
            fishRenderer.sprite = fishSprite;
            SetActive(true);

            var wait = new WaitForSeconds(2);
            yield return wait;

            SetActive(false);
        }
        #endregion
    }
}