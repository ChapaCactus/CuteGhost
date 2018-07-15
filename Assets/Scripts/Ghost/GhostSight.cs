using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GhostSight : MonoBehaviour
    {
        #region inner classes
        public class Container
        {
            public List<GameObject> list { get; set; } = new List<GameObject>();
        }
        #endregion

        #region enums
        public enum TargetTag
        {
            NotTarget = -100,

            NPC = 100,
        }
        #endregion

        #region properties
        public Dictionary<TargetTag, Container> npcDic { get; private set; }

        private CircleCollider2D collider2d { get; set; }
        private Action onInsightEnter { get; set; }
        private Action onInsightExit { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            // Init Dic
            npcDic = new Dictionary<TargetTag, Container>();
            var targetTags = Enum.GetValues((typeof(TargetTag)))
                           .Cast<TargetTag>()
                           .ToList();
            targetTags.ForEach(targetTag =>
            {
                if (targetTag != TargetTag.NotTarget)
                    npcDic.Add(targetTag, new Container());
            });

            // Init Component
            collider2d = GetComponent<CircleCollider2D>();
            collider2d.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // 衝突相手のTagをTargetTagとして取得
            var tag = ConvertStringToTargetTag(collision.tag);

            // 想定外のタグなら何もしない
            if (tag == TargetTag.NotTarget)
                return;

            if (!npcDic.ContainsKey(tag))
                return;

            var container = npcDic[tag];
            var targets = container.list;

            var isFound = targets.Any(item => item == collision.gameObject);
            if (!isFound)
            {
                targets.Add(collision.gameObject);
                onInsightEnter();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // 衝突相手のTagをTargetTagとして取得
            var tag = ConvertStringToTargetTag(collision.tag);

            // 想定外のタグなら何もしない
            if (tag == TargetTag.NotTarget)
                return;

            if (!npcDic.ContainsKey(tag))
                return;

            var container = npcDic[tag];
            var targets = container.list;

            var isFound = targets.Any(item => item == collision.gameObject);
            if (isFound)
            {
                targets.Remove(collision.gameObject);
                onInsightExit();
            }
        }
        #endregion

        #region public methods
        public void SetCallbacks(Action onInsightEnter, Action onInsightExit)
        {
            this.onInsightEnter = onInsightEnter;
            this.onInsightExit = onInsightExit;
        }

        public TargetTag GetHighestTagInsight()
        {
            if (npcDic[TargetTag.NPC].list.Count >= 1)
                return TargetTag.NPC;

            return TargetTag.NotTarget;
        }
        #endregion

        #region private methods
        private TargetTag ConvertStringToTargetTag(string tag)
        {
            switch (tag)
            {
                case "NPC":
                    return TargetTag.NPC;
                default:
                    return TargetTag.NotTarget;
            }
        }
        #endregion
    }
}