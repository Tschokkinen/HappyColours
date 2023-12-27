using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ColourFeed
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private GameObject square;
        [SerializeField] private Vector3 extents;
        [SerializeField] private List<GameObject> squaresOnScreen = new List<GameObject>();
        [SerializeField] private Button backToMain;

        // Start is called before the first frame update
        void Start()
        {
            backToMain.onClick.AddListener(BackToMain);
            extents = square.GetComponent<SpriteRenderer>().bounds.extents;
            // Instantiation positions must be divisible by 2.5f!
            squaresOnScreen.Add(Instantiate(square));
            squaresOnScreen.Add(Instantiate(square, new Vector3(0.0f, (3f * (-extents.y)), 0.0f), Quaternion.identity));
            squaresOnScreen.Add(Instantiate(square, new Vector3(0.0f, (6f * (-extents.y)), 0.0f), Quaternion.identity));
            squaresOnScreen.Add(Instantiate(square, new Vector3(0.0f, (9f * (-extents.y)), 0.0f), Quaternion.identity));
            ColourFeed.Square.SquareDestroyed += InstantiateSquare;

            TouchControls.screenDrag += Move;
        }

        private void BackToMain()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        private void Move(object sender, EventArgs e)
        {
            foreach(GameObject go in squaresOnScreen)
            {
                if (go == null) 
                {
                    squaresOnScreen.Remove(go);
                    continue;
                }
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + 0.1f, go.transform.position.z);
            }
        }

        private void InstantiateSquare(object sender, EventArgs e)
        {
            squaresOnScreen.Add(Instantiate(square, new Vector3(0.0f, (6.0f * (-extents.y)), 0.0f), Quaternion.identity));
        }
    }

}
