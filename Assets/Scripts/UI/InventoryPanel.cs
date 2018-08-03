using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class InventoryPanel : MonoBehaviour
    {
        #region public methods
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        #endregion
    }
}