using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.TouchSupport
{
    public abstract class BaseTouchObserver : MonoBehaviour
    {
        [SerializeField] protected LayerMask mask;
        [SerializeField] protected int maxHits = 30;

        public event Action<Touch> OnTouchBegin;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    OnTouchBegin?.Invoke(Input.touches[i]);
                    CastAtTouch(Input.touches[i]);
                }
            }
        }

        protected abstract void CastAtTouch(Touch touch);
    }
}

