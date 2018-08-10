using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class EncounterManager : SingletonMonoBehaviour<EncounterManager>
    {
        #region properties
        public int StepOfEncounter { get; private set; }

        private Action OnEncounter { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            StepOfEncounter = 100;
        }
        #endregion

        #region public methods
        public void OnMove()
        {
            if (StepOfEncounter <= 0)
                return;

            StepOfEncounter--;

            Debug.Log(StepOfEncounter);

            if(StepOfEncounter == 0)
            {
                OnEncounter.SafeCall();
                Encounter();
            }
        }
        #endregion

        #region private methods
        private void Encounter()
        {
            var battleGroup = EnemyGroupMaster.Instance.GetRow(EnemyGroupMaster.rowIds.ID_001);
            var enemies = new List<IFightable>()
                        {
                            (string.IsNullOrEmpty(battleGroup._Enemy1) ? Enemy.Empty() : new Enemy(battleGroup._Enemy1)),
                            (string.IsNullOrEmpty(battleGroup._Enemy2) ? Enemy.Empty() : new Enemy(battleGroup._Enemy2)),
                            (string.IsNullOrEmpty(battleGroup._Enemy3) ? Enemy.Empty() : new Enemy(battleGroup._Enemy3)),
                        };

            var battleSetting = new BattleManager.BattleSetupData(Global.Player, enemies, battleGroup._Background);
            Global.BattleManager.StartBattle(battleSetting);
        }
        #endregion
    }
}