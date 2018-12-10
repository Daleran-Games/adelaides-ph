using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Renderers
{
    [RequireComponent(typeof(LineRenderer))]
    [ExecuteInEditMode]
    public class TransformLineConnector : MonoBehaviour
    {
        [SerializeField]
        Transform[] transforms;
        public Transform[]  Transforms
        {
            get { return transforms; }
            set
            {
                transforms = value;
                Render();
            }
        }

        private LineRenderer lineRenderer;

        private void OnValidate()
        {
            Render();
        }

        // Use this for initialization
        void Start()
        {
            Render();
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < transforms.Length; i++)
            {
                if (transforms[i].hasChanged)
                    Render();
            }
        }

        private void Render()
        {
            if (lineRenderer == null)
                lineRenderer = GetComponent<LineRenderer>();

            if (lineRenderer.useWorldSpace != true)
                lineRenderer.useWorldSpace = true;

            lineRenderer.positionCount = transforms.Length;
            lineRenderer.SetPositions(GetPositions(transforms));

        }

        private Vector3[] GetPositions(Transform[] transforms)
        {
            Vector3[] positions = new Vector3[transforms.Length];

            for (int i=0;i<transforms.Length;i++)
            {
                positions[i] = transforms[i].position;
            }

            return positions;
        }
    }
}