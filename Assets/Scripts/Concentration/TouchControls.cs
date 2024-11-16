using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concentration
{
    public class TouchControls : MonoBehaviour
    {
        GameController gameController;
        [SerializeField] bool mouseClick;
        [SerializeField] GameObject touchMarker;

        void Start()
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

        // Update is called once per frame
        void Update()
        {

            #if UNITY_IOS || UNITY_ANDROID
            // Touch controls
            foreach (Touch touch in Input.touches)
            {
                //Ray ray = Camera.main.ScreenPointToRay(touch.position);
                //RaycastHit hit;

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.transform != null && hit.collider.gameObject == gameController.activeGO)
                        {
                            // Debug.Log("Touched active square");
                            gameController.StartIncrementPoints();
                            SetMarkerPos(Camera.main.ScreenToWorldPoint(touch.position));
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.transform != null && hit.collider.gameObject != gameController.activeGO)
                        {
                            gameController.StopIncrementPoints();
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    gameController.StopIncrementPoints();
                }
            }
            #endif

            #if UNITY_EDITOR || UNITY_WEBGL
            // Mouse controls
            if (Input.GetMouseButton(0))
            {
                // Debug.Log("Mouse click");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.transform != null && hit.collider.gameObject == gameController.activeGO && !mouseClick)
                    {
                        // Debug.Log("Mouse button down on active square");
                        gameController.StartIncrementPoints();
                        mouseClick = true;
                        SetMarkerPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    }
                    else if (hit.collider.transform != null && hit.collider.gameObject != gameController.activeGO && mouseClick)
                    {
                        gameController.StopIncrementPoints();
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                // Debug.Log("Mouse button release");
                gameController.StopIncrementPoints();
                mouseClick = false;
            }
            #endif
        }

        private void SetMarkerPos(Vector3 pos)
        {
            touchMarker.transform.position = new Vector3(pos.x, pos.y, 0);
            touchMarker.GetComponent<TouchMarker>().PlayAnimation();
        }
    }
}