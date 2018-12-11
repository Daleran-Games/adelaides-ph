using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [AddComponentMenu("Rendering/Main Camera")]
    public class MainCamera : MonoBehaviour
    {
        [SerializeField]
        static Camera instance;
        public static Camera Instance
        { get
            {
                if (instance == null)
                    instance = Camera.main;
                return instance;
            }
        }

    }

}
