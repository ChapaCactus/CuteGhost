using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;
using UnityEngine.SceneManagement;

namespace CCG
{
    public class EncounterManager : SingletonMonoBehaviour<EncounterManager>
    {
        #region properties
        public int StepOfEncounter { get; private set; }

        // 今プレイヤーが居るエンカウントエリア
        private EncountArea CurrentArea { get; set; }
        private Action OnEncounter { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();
        }
        #endregion

        #region public methods
        public void OnMove()
        {
            if (CurrentArea == null
                || StepOfEncounter <= 0)
                return;

            StepOfEncounter--;

            Debug.Log(StepOfEncounter);

            if(StepOfEncounter == 0)
            {
                OnEncounter.SafeCall();
                Encounter();
            }
        }

        public void SetCurrentArea(EncountArea area)
        {
            Debug.Log($"SetEncountArea [{CurrentArea} -> {area}]");

            CurrentArea = area;
            StepOfEncounter = 500;// TODO: エリアごとにエンカウント率を設定し、そこから初期化するようにする
        }
        #endregion

        #region private methods
        private void Encounter()
        {
            var battleGroup = EnemyGroupMaster.Instance.GetRow(EnemyGroupMaster.rowIds.ID_001);
            var enemies = new List<Enemy>()
                        {
                            (string.IsNullOrEmpty(battleGroup._Enemy1) ? Enemy.Empty() : new Enemy(battleGroup._Enemy1)),
                            (string.IsNullOrEmpty(battleGroup._Enemy2) ? Enemy.Empty() : new Enemy(battleGroup._Enemy2)),
                            (string.IsNullOrEmpty(battleGroup._Enemy3) ? Enemy.Empty() : new Enemy(battleGroup._Enemy3)),
                        };

            string sceneName = SceneManager.GetActiveScene().name;
            Vector2 encountedPlayerPosition = PlayerController.I.transform.position;
            var battleSetting = new BattleManager.BattleSetting(Global.Player, enemies, battleGroup._Background
                                                                  , sceneName, encountedPlayerPosition);
            Global.BattleManager.StartBattle(battleSetting);
        }

        private void Init()
        {
            CurrentArea = null;
            StepOfEncounter = 0;
        }
        #endregion
    }
}