using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.UFO
{
    public static class PoolingManager
    {
        #region properties
        public static List<IPoolable> PoolingList { get; private set; }
        #endregion

        #region public methods
        public static void Pick(string identifier, Action<IPoolable> onSuccess)
        {
            var poolable = PoolingList.FirstOrDefault(element => element.GetIsPooling());
            if (poolable != null)
            {
                onSuccess(poolable);
            } else
            {
                Register(identifier);
                Pick(identifier, onSuccess);
            }
        }
        #endregion

        #region private methods
        private static void Register(string identifier)
        {
            var poolable = Create(identifier);
            var uid = PoolingIdentifierManager.CreateUid();
            poolable.SetUid(uid);

            PoolingList.Add(poolable);
        }

        private static IPoolable Create(string identifier)
        {
            return null;
        }
        #endregion
    }
}