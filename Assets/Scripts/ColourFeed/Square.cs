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
            // TouchControls.screenDrag += Move;
        }

        private void ColourText()
        {
            int rnd = UnityEngine.Random.Range(0, 3);
            text.text = Database.GetText(rnd);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = new Vector3(transform.position.x, (transform.position.y + extents.y));
            }

            if (this.gameObject.transform.position.y >= 15.0f)
            {
                SquareDestroyed?.Invoke(this, EventArgs.Empty);
                Debug.Log(gameObject.transform.position);
                Destroy(this.gameObject);
            }



        }

        // IEnumerator LerpColor()
        // {
        //     float i = 0.0f;
        //     while (i < 20000)
        //     {
        //         Color rnd1 = spriteRenderer.color;
        //         Color rnd2 = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //         Color lerped = Color.Lerp(rnd1, rnd2, Mathf.PingPong(Time.time, 1));
        //         spriteRenderer.color = lerped;
        //         i++;
        //     }

        //     yield return null;
        // }

        // private void Move(object sender, EventArgs e)
        // {
        //     this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.x + 1.0f, transform.position.z);
        // }
    }
}

