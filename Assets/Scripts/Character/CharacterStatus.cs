using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class CharacterStatus
    {
        public string CharaName { get; set; }

        public int Level { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int ATK { get; set; }

        public bool IsDead { get { return Health <= 0; } }

        public void SetData(EnemyMasterRow row)
        {
            CharaName = row._Name;

            Level = row._Level;

            MaxHealth = row._MaxHealth;
            Health = MaxHealth;

            ATK = row._ATK;
        }

        public void Damage(int damage)
        {
            Debug.Log($"Health{Health} - Damage{damage} => {Health - damage}");
            Health -= damage;

            if(Health < 0)
            {
                Health = 0;
            }
        }

        public void Cure(int cure)
        {
            Health += cure;
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            UIManager.I.SetupStatusPanel(this);
        }
    }
}