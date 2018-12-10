using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.PixelArt
{
    [AddComponentMenu("Rendering/Pixel Perfect Camera")]
    [RequireComponent(typeof(Camera))]
    [ExecuteInEditMode]
    public class PixelPerfectCamera : MonoBehaviour
    {
        [SerializeField]
        int pixelsPerUnit = 1;
        public float PixelsPerUnit { get { return pixelsPerUnit; } }

        float unitsInPixels;
        public float UnitsInPixel { get { return unitsInPixels; } }

        [SerializeField]
        bool scaleOnStart = true;

        [SerializeField]
        [Range(1,20)]
        int scale = 1;
        public int Scale
        {
            get { return scale; }
            set
            {
                if (value > 0)
                {
                    scale = value;
                    ScaleCamera();
                    ScaleChanged?.Invoke(scale); 
                }
            }
        }
        public event Action<int> ScaleChanged;

        protected Camera cam;
        // Use this for initialization
        private void Awake()
        {
            cam = gameObject.GetRequiredComponent<Camera>();
            unitsInPixels = 1 / pixelsPerUnit;
        }

        void Start()
        {
            if (scaleOnStart)
                ScaleCamera();
        }

        private void OnValidate()
        {
            unitsInPixels = 1 / pixelsPerUnit;
            ScaleCamera();
        }

        protected virtual float CalculateOrthographicSize(float scale)
        {
            return (Screen.height / (scale * PixelsPerUnit)) * 0.5f;
        }

        [ContextMenu("Scale Camera")]
        public void ScaleCamera()
        {
            if (cam == null)
                cam = gameObject.GetRequiredComponent<Camera>();

            ScaleCamera(Scale);
        }

        public void ScaleCamera(int scale)
        {
            cam.orthographicSize = CalculateOrthographicSize(scale);
        }

    }
}

