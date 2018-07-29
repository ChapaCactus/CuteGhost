using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using HedgehogTeam.EasyTouch;

namespace CCG
{
    [RequireComponent(typeof(QuickTap))]
    public class BattleEnemyController : MonoBehaviour
    {
        #region variables
        #endregion

        #region properties
        private QuickTap QuickTap { get; set; }

        public Enemy Enemy { get; private set; }
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
            Enemy = enemy;
        }

        public void OnTap(Gesture gesture)
        {
            if(Enemy == null)
            {
                Debug.Log("Not Set Enemy.");
                return;
            }

            BattleSceneController.I.OnClickEnemy(Enemy);
        }
        #endregion
    }
}