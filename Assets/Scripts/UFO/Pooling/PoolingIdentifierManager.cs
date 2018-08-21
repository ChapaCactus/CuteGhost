using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.UFO
{
    public static class PoolingIdentifierManager
    {
        #region public methods
        /// <summary>
        /// 新規で固有IDを発行
        /// </summary>
        public static string CreateUid()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion
    }
}