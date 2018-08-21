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
        public static void Register(IPoolable poolable)
        {
            if (PoolingList.Any(element => element.GetUid() == poolable.GetUid()))
                return;

            var uid = PoolingIdentifierManager.CreateUid();
            poolable.SetUid(uid);

            PoolingList.Add(poolable);
        }

        public static void Pick(Action<IPoolable> onSuccess)
        {
            var poolable = PoolingList.FirstOrDefault(element => element.GetIsPooling());
            if (poolable != null)
                onSuccess(poolable);
        }
        #endregion
    }
}