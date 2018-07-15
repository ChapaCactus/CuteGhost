using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Google2u;

namespace CCG
{
    public class QuestVO
    {
        #region properties
        public QuestMaster.rowIds id { get; private set; }
        public string name { get; private set; }
        public string type { get; private set; }
        public int target { get; private set; }
        public string description { get; private set; }
        #endregion

        #region public methods
        public static QuestVO Create(QuestMaster.rowIds id)
        {
            var row = QuestMaster.Instance.GetRow(id);

            var vo = new QuestVO();
            vo.id = id;
            vo.name = row._Name;
            vo.type = row._Type;
            vo.target = row._Target;
            vo.description = row._Description;

            return vo;
        }
        #endregion
    }
}