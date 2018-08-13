using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EncountArea : MonoBehaviour
    {
        #region private methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                EncounterManager.I.SetCurrentArea(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                EncounterManager.I.SetCurrentArea(null);
            }
        }
        #endregion
    }
}