using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TouchSupport
{
    public class TouchInstantiator : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] BaseTouchObserver observer;

        private void OnEnable()
        {
            observer.OnTouchBegin += OnTouch;
        }

        private void OnDisable()
        {
            observer.OnTouchBegin -= OnTouch;
        }

        void OnTouch(Touch touch)
        {
            Instantiate(prefab, touch.position, Quaternion.identity);
        }
    }
}