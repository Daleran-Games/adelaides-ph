using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaleranGames.TouchSupport
{
    public class TouchUnityEvent : MonoBehaviour, ITouchable
    {
        public UnityEvent OnTouch;

        public void Touch(Touch touch)
        {
            OnTouch?.Invoke();
        }
    }
}

