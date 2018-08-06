using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class ExpTable
    {
        #region enums
        public enum CharacterType
        {
            Player,
            Friend,
        }
        #endregion

        #region public methods
        public int GetExpFromLevel(CharacterType type, int level)
        {
            var padLeft = level.ToString().PadLeft(2, '0');
            var key = $"ID_{padLeft}";

            switch (type)
            {
                case CharacterType.Player:
                    return GetPlayerExpFromLevel(key);
                case CharacterType.Friend:
                    return GetFriendExpFromLevel(key);
                default:
                    return 9999999;// 適当な巨大数を返す
            }
        }
        #endregion

        #region private methods
        private int GetPlayerExpFromLevel(string key)
        {
            return PlayerExpTable.Instance.GetRow(key)._Exp;
        }

        private int GetFriendExpFromLevel(string key)
        {
            return FriendExpTable.Instance.GetRow(key)._Exp;
        }
        #endregion
    }
}