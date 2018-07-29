using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class CharacterStatus
    {
        public int Level { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int ATK { get; set; }
    }
}