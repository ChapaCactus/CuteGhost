using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public interface IBattleCharacter
    {
        void Damage(int damage);
    }
}