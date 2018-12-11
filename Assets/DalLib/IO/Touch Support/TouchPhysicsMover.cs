using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TouchSupport
{
    
    public class TouchPhysicsMover : MonoBehaviour, ITouchable
    {
        [SerializeField] Rigidbody2D rigidbody;

        [SerializeField] float force = 10f;

        [SerializeField] Vector2 moveDirection = Vector2.zero;

        // Start is called before the first frame update
        void Awake()
        {
            if (rigidbody == null)
                rigidbody = GetComponent<Rigidbody2D>();


        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rigidbody.AddForce(moveDirection * force);
            moveDirection = Vector2.zero;
        }

        public void Touch(Touch touch)
        {
            moveDirection = touch.deltaPosition.normalized;    
        }
    }
}