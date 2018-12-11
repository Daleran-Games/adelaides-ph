using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Transformers
{
    public class ConstantTranslatorClamped : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] float minX = -20f;
        [SerializeField] float maxX = 20f;
        [SerializeField] Vector2 moveDirection = Vector2.right;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);

            if (transform.position.x < minX)
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            else if (transform.position.x > maxX)
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }
}

