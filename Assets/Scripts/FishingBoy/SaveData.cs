using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.FishingBoy
{
    public class SaveData
    {
        public int Gold { get; private set; }
        public List<Fish> Fishes { get; private set; }
    }
}