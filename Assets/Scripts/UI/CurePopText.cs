using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    [RequireComponent(typeof(Text))]
    public class CurePopText : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text text = null;
        #endregion

        #region properties
        private Sequence Sequence { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            gameObject.SetActive(false);
            text.color = Color.green;
        }
        #endregion

        #region public methods
        public void Play(int cure)
        {
            if(Sequence != null)
            {
                Sequence.Kill();
                Sequence = null;
            }

            text.text = $"+{cure}";
            text.color = Color.green;
            gameObject.SetActive(true);

            Sequence = DOTween.Sequence();
            Sequence.OnComplete(() => gameObject.SetActive(false));
            Sequence.Append(text.DOFade(1, 1)
                            .SetEase(Ease.InExpo));
            Sequence.Append(text.transform.DOLocalMoveY(3, 1)
                            .SetRelative());
        }
        #endregion
    }
}