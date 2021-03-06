﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Threading.Tasks;
using DG.Tweening;
using HedgehogTeam.EasyTouch;
using DarkTonic.MasterAudio;

namespace CCG
{
    [RequireComponent(typeof(QuickTap))]
    public class BattleEnemyController : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        #endregion

        #region properties
        private QuickTap QuickTap { get; set; }

        public Enemy Enemy { get; private set; }
        public CharacterStatus Status { get { return Enemy.Status; } }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            QuickTap = GetComponent<QuickTap>();
            QuickTap.onTap.AddListener(OnTap);
        }
        #endregion

        #region public methods
        public void Setup(Enemy enemy)
        {
            if(enemy.IsEmpty)
            {
                SetActive(false);
                return;
            }

            Enemy = enemy;
            Enemy.SetOnDead(() => { });

            // 画像読み込み・セット
            spriteRenderer.sprite = Utilities.LoadSprite(enemy.SpritePath);
        }

        public void OnTap(Gesture gesture)
        {
            if (Enemy == null)
            {
                Debug.Log("Not Set Enemy.");
                return;
            }

            BattleSceneController.I.OnClickEnemy(this);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public IEnumerator PlayDamageEffect()
        {
            MasterAudio.PlaySound("EnemyHit");

            var sequence = DOTween.Sequence();
            sequence.OnComplete(() =>
            {
                spriteRenderer.color = Color.white;

                if (Enemy.IsDead)
                {
                    MasterAudio.PlaySound("EnemyDead");
                    SetActive(false);
                }
            });
            sequence.Append(spriteRenderer.DOFade(0, 0.1f));
            sequence.Append(spriteRenderer.DOFade(1, 0.1f));
            sequence.Append(spriteRenderer.DOFade(0, 0.1f));
            sequence.Append(spriteRenderer.DOFade(1, 0.1f));
            sequence.Append(spriteRenderer.DOFade(0, 0.1f));

            yield return new WaitForSeconds(0.55f);
        }
        #endregion
    }
}