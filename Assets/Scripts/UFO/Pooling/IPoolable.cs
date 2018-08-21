using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public interface IPoolable
    {
        void SetUid(string uid);
        string GetUid();

        bool GetIsPooling();
    }
}