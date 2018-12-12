using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.TouchSupport
{
    public class TouchObserver2D : BaseTouchObserver
    {
        [SerializeField] float castRadius = 0.1f;

        Collider2D[] hits;

        private void Awake()
        {
            hits = new Collider2D[maxHits];
        }

        protected override void CastAtTouch(Touch touch)
        {
            int results = Physics2D.OverlapCircleNonAlloc(MainCamera.Instance.ScreenToWorldPoint(touch.position), castRadius, hits, mask.value);

            if (results > 0)
            {
                for (int i = 0; i < results; i++)
                {
                    InvokeTouchables(i, touch);
                }
            }
        }

        void InvokeTouchables(int hitIndex, Touch touch)
        {
            ITouchable[] touchables = hits[hitIndex].gameObject.GetComponents<ITouchable>();

            if (touchables.Length > 0)
            {
                for (int i = 0; i < touchables.Length; i++)
                {
                    touchables[i].Touch(touch);
                }
            }
        }

    }
}