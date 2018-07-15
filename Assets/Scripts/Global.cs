using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class Global
    {
        #region properties
        public static QuestManager questManager { get; private set; }
        #endregion

        #region public methods
        public static void Init()
        {
            questManager = new QuestManager();
        }
        #endregion
    }
}