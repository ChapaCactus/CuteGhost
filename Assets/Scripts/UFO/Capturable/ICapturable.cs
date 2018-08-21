using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public interface ICapturable
    {
        CapturableStatus GetStatus();
        void Gain();
    }
}