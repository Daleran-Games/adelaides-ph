using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.TouchSupport
{
    public class TouchMediator2D : MonoBehaviour
    {
        [SerializeField] float castRadius = 0.1f;
        [SerializeField] LayerMask mask;
        [SerializeField] int maxHits = 30;

        Collider2D[] hits;

        public event Action<Touch> OnTouchBegin;

        private void Awake()
        {
            hits = new Collider2D[maxHits];
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    int results = Physics2D.OverlapCircleNonAlloc(MainCamera.Instance.ScreenToWorldPoint(Input.touches[i].position), castRadius, hits, mask.value);

                    if (results > 0)
                    {

                        for (int k = 0; k < results; k++)
                        {
                            ITouchable[] touchables = hits[k].gameObject.GetComponents<ITouchable>();

                            if (touchables.Length > 0)
                            {
                                for (int j = 0; j < touchables.Length; j++)
                                {
                                    touchables[j].Touch(Input.touches[i]);
                                }
                            }
                        }
                    }
                }          
            }
        }




    }
}