using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    public class KeyUnityEvent : InputUnityEvent
    {
        [SerializeField] KeyCode code = KeyCode.Return;

        protected override bool CheckForInput()
        {
            switch(type)
            {
                case InputType.Any:
                    if (Input.GetKey(code))
                        return true;
                    break;
                case InputType.Down:
                    if (Input.GetKeyDown(code))
                        return true;
                    break;
                case InputType.Up:
                    if (Input.GetKeyUp(code))
                        return true;
                    break;
            }
            return false;
        }
    }
}