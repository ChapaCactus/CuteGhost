using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class CharacterStatus
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int ATK { get; set; }

        public void SetData(EnemyMasterRow row)
        {
            Name = row._Name;

            Level = row._Level;

            MaxHealth = row._MaxHealth;
            Health = row._MaxHealth;

            ATK = row._ATK;
        }
    }
}