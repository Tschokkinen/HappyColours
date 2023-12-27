using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concentration
{
    public class Square : MonoBehaviour
    {
        public bool activeStatus;
        SpriteRenderer spriteRenderer;
        [SerializeField] Color turquoise;
        [SerializeField] Color orange;
        [SerializeField] Color purple;
        [SerializeField] Color pink;
        [SerializeField] Color gray;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            SetInactiveStatus();
        }

        public void SetActiveStatus()
        {
            activeStatus = true;
            spriteRenderer.color = GetNextColor();
        }

        public void SetInactiveStatus()
        {
            activeStatus = false;
            spriteRenderer.color = new Color(gray.r, gray.g, gray.b, 1f);
        }

        private Color GetNextColor()
        {
            float rnd = Random.Range(0.0f, 30.0f);
            Debug.Log($"Random value: {rnd}");
            switch (rnd)
            {
                case float val when (val > 10.0f && val < 20.0f):
                    return orange;
                case float val when (val > 20.0f && val < 30.0f):
                    return turquoise;
                default:
                    return pink;
            }
        }

    }
}