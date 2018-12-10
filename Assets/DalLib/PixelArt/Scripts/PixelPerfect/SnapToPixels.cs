using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.PixelArt
{
    [AddComponentMenu("Rendering/Pixel Snap")]
    public class SnapToPixels : MonoBehaviour
    {

        public float PixelsPerUnit = 16; // pixels per unit (your tile size)

        private void LateUpdate()
        {
            Vector3 position = transform.localPosition;
            position.x = (Mathf.Round(transform.parent.position.x * PixelsPerUnit) / PixelsPerUnit) - transform.parent.position.x;
            position.y = (Mathf.Round(transform.parent.position.y * PixelsPerUnit) / PixelsPerUnit) - transform.parent.position.y;
            transform.localPosition = position;
        }

    }
}
