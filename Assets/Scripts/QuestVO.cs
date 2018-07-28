using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;
using System.Text.RegularExpressions;

namespace CCG
{
    public class QuestVO
    {
        #region properties
        public string id { get; private set; }
        public int idInt { get; private set; }
        public string name { get; private set; }
        public string type { get; private set; }
        public int target { get; private set; }
        public string description { get; private set; }
        #endregion

        #region public methods
        public static QuestVO Create(string id)
        {
            var row = QuestMaster.Instance.GetRow(id);

            var vo = new QuestVO();
            vo.id = id;
            vo.idInt = ConvertRowIdToInt(id);
            vo.name = row._Name;
            vo.type = row._Type;
            vo.target = row._Target;
            vo.description = row._Description;

            return vo;
        }
        #endregion

        #region private methods
        /// <summary>
        /// QuestMasterIdをintに変換する
        /// </summary>
        private static int ConvertRowIdToInt(string id)
        {
            var number = Regex.Match(id, @"\d+")
                              .Value;

            return int.Parse(number);
        }
        #endregion
    }
}