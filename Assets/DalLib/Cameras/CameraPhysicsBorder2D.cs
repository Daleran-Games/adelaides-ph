using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Cameras
{
    public class CameraPhysicsBorder2D : MonoBehaviour
    {
        [SerializeField] EdgeCollider2D collider;
        
        // Start is called before the first frame update
        void Awake()
        {
            if (collider == null)
                collider = GetComponent<EdgeCollider2D>();

            float horzSize = MainCamera.Instance.orthographicSize * Screen.width / Screen.height;
            collider.points = new Vector2[] {   new Vector2(-horzSize,MainCamera.Instance.orthographicSize),
                                                new Vector2(-horzSize,-MainCamera.Instance.orthographicSize),
                                                new Vector2(horzSize,-MainCamera.Instance.orthographicSize),
                                                new Vector2(horzSize,MainCamera.Instance.orthographicSize),
                                                new Vector2(-horzSize,MainCamera.Instance.orthographicSize)};
        }

    }
}

