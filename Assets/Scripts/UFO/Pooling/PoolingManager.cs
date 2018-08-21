using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.UFO
{
    public class PoolingManager : SingletonMonoBehaviour<PoolingManager>
    {
        #region properties
        public List<IPoolable> PoolingList { get; private set; } = new List<IPoolable>();
        #endregion

        #region unity callbacks
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Pick("MaguroMan", poolable => {
                    poolable.Pick();
                });
            }
        }
        #endregion

        #region public methods
        public void Pick(string identifier, Action<IPoolable> onSuccess)
        {
            var poolable = PoolingList.FirstOrDefault(element => element.GetIsPooling());
            if (poolable != null)
            {
                onSuccess.SafeCall(poolable);
            } else
            {
                Register(identifier);
                Pick(identifier, onSuccess);
            }
        }
        #endregion

        #region private methods
        private void Register(string identifier)
        {
            var poolable = Create(identifier);
            var uid = PoolingIdentifierManager.CreateUid();
            poolable.SetUid(uid);
            poolable.Pool();

            PoolingList.Add(poolable);
        }

        private IPoolable Create(string identifier)
        {
            var prefab = Resources.Load($"Prefabs/UFO/{identifier}") as GameObject;
            var poolable = GameObject.Instantiate(prefab, null).GetComponent<IPoolable>();
            return poolable;
        }
        #endregion
    }
}