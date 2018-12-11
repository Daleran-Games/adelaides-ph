using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaleranGames.IO
{
    public abstract class InputUnityEvent : MonoBehaviour
    {
        public enum InputType
        {
            Up,
            Down,
            Any
        }

        [SerializeField] protected InputType type = InputType.Down;
        public UnityEvent OnInput;

        // Update is called once per frame
        void Update()
        {
            if (CheckForInput())
                OnInput?.Invoke();
        }

        protected abstract bool CheckForInput();
    }
}

