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
        public int Exp { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int MaxSpecialPoint { get; set; }
        public int SpecialPoint { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        public bool IsDead { get { return Health <= 0; } }

        public void UpdateStatus(PlayerStatusTableRow row)
        {
            this.MaxHealth = row._Health;
            this.Health = row._Health;// 最大値に揃える

            this.MaxSpecialPoint = row._SpecialPoint;
            this.SpecialPoint = row._SpecialPoint;

            this.Attack = row._Attack;
            this.Defense = row._Defense;
            this.Speed = row._Speed;
            this.Luck = row._Luck;
        }

        public void UpdateStatus(FriendStatusTableRow row)
        {
            this.MaxHealth = row._Health;
            this.Health = row._Health;// 最大値に揃える

            this.MaxSpecialPoint = row._SpecialPoint;
            this.SpecialPoint = row._SpecialPoint;

            this.Attack = row._Attack;
            this.Defense = row._Defense;
            this.Speed = row._Speed;
            this.Luck = row._Luck;
        }

        public void SetData(EnemyMasterRow row)
        {
            CharaName = row._Name;

            Level = row._Level;
            Exp = row._GainExp;

            MaxHealth = row._MaxHealth;
            Health = MaxHealth;

            Attack = row._ATK;
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