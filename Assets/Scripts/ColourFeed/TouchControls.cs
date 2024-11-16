using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColourFeed
{
    public class TouchControls : MonoBehaviour
    {
        [SerializeField] private Vector2 currentPos;
        [SerializeField] private Vector2 direction;
        [SerializeField] private Vector2 startPosMouse;

        public static event EventHandler? screenDrag;

        // Update is called once per frame
        void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    currentPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    currentPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    direction = touch.position;
                    if (direction.y > currentPos.y)
                    {
                        Debug.Log("Broadcast: Move objects");
                        screenDrag?.Invoke(this, EventArgs.Empty);
                    }
                }

            }
        }

        void OnMouseDown()
        {
            startPosMouse = Input.mousePosition;
        }

        void OnMouseDrag()
        {
            Debug.Log(Input.mousePosition);
            Vector3 movePos = Input.mousePosition;

            if (movePos.y > startPosMouse.y)
            {
                Debug.Log("Mouse dragged downwards");
                screenDrag?.Invoke(this, EventArgs.Empty);
            }

            startPosMouse = Input.mousePosition;
        }
    }
}