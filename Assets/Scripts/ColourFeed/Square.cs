using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ColourFeed
{
    public class Square : MonoBehaviour
    {
        public Vector3 extents;
        public SpriteRenderer spriteRenderer;
        [SerializeField] private TextMeshProUGUI text;
        public static event EventHandler? SquareDestroyed;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            extents = spriteRenderer.bounds.extents;

            ColourText();
        }

        private void ColourText()
        {
            int rnd = UnityEngine.Random.Range(0, 3);
            text.text = Database.GetText(rnd);
        }

        // Update is called once per frame
        void Update()
        {
            if (this.gameObject.transform.position.y >= 15.0f)
            {
                SquareDestroyed?.Invoke(this, EventArgs.Empty);
                Debug.Log(gameObject.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}

