using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public interface IBattleCharacter
    {
        // ステータス参照
        CharacterStatus Status { get; }

        void Damage(int damage);

        bool GetIsDead();
    }
}