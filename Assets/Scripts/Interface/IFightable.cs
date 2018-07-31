using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public interface IFightable
    {
        // ステータス参照
        CharacterStatus Status { get; }
        bool IsDead { get; }

        void Attack(IFightable target);
        void Damage(CharacterStatus attacker);
    }
}