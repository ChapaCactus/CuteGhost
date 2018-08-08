using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public struct SaveData
    {
        public string name;

        public int level;
        public int exp;

        public static SaveData NewData()
        {
            var newData = new SaveData()
            {
                name = "NO NAME",
                level = 1,
                exp = 0,
            };

            return newData;
        }
    }
}