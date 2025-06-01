using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Concentration
{
    public class GameController : MonoBehaviour
    {
        // [Header("DLL")]
        // public Timer timer;

        [Header("Database")]
        public Database database;

        [Header("UI")]
        public GameObject activeGO;
        [SerializeField] private GameObject[] squares;
        [SerializeField] private GameObject currentSquare;
        [SerializeField] private float maxWaitTime;
        [SerializeField] Button quitGame;
        SpriteRenderer spriteRenderer;
        [SerializeField] private int points;
        Coroutine coroutine;

        [Header("Quit game panel")]
        [SerializeField] GameObject panel;
        [SerializeField] TMP_Text pointText;
        [SerializeField] TMP_Text lastTimePoints;
        [SerializeField] TMP_Text curPoints;
        [SerializeField] TMP_Text playTime;
        [SerializeField] int lastColour;

        // Start is called before the first frame update
        void Start()
        {
            lastColour = 10;
            maxWaitTime = (maxWaitTime == 0.0f) ? 4.0f : maxWaitTime;
            StartCoroutine(ChangeColor());
            coroutine = null;

            quitGame.onClick.AddListener(BackToMain);
            panel.SetActive(false);


            // GetPrevPoints();
        }

        IEnumerator ChangeColor()
        {
            while (true)
            {
                GameObject square = GetNextSquare();
                yield return new WaitForSeconds(maxWaitTime);
                square.GetComponent<Square>().SetActiveStatus();
                activeGO = square;
                SetInactive();
            }
        }

        GameObject GetNextSquare()
        {
            int val;
            do
            {
                val = Random.Range(1, 5);
            } while (val == lastColour);

            lastColour = val;
            
            
            // if (val < 25.0f && currentSquare != squares[0]) return squares[0];
            // if (val < 50.0f && val > 25.0f && currentSquare != squares[1]) return squares[1];
            // if (val < 75.0f && val > 50.0f && currentSquare != squares[2]) return squares[2];
            // if (val > 75.0f && currentSquare != squares[3]) return squares[3];

            if (val == 1 && currentSquare != squares[0]) return squares[0];
            if (val == 2 && currentSquare != squares[1]) return squares[1];
            if (val == 3 && currentSquare != squares[2]) return squares[2];
            if (val == 4 && currentSquare != squares[3]) return squares[3];
            return null;
        }

        void SetInactive()
        {
            foreach (GameObject go in squares)
            {
                if (go != activeGO) go.GetComponent<Square>().SetInactiveStatus();
            }
        }

        public void StartIncrementPoints()
        {
            coroutine = StartCoroutine(IncrementPoints());
        }

        public void StopIncrementPoints()
        {
            if (coroutine != null) StopCoroutine(coroutine);
            // Debug.Log("Coroutine stopped");
        }

        // Increment points
        IEnumerator IncrementPoints()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                points += 1;
                Debug.Log($"Points: {points}");
                UpdateCurPoints();
            }
        }

        // Update point counter text
        private void UpdateCurPoints()
        {
            curPoints.text = $"Points: {points}";
        }

        private void BackToMain()
        {
            StartCoroutine(BackToMainCoroutine());
        }

        IEnumerator BackToMainCoroutine()
        {
            Debug.Log("Button click");
            panel.SetActive(true);
            pointText.text = pointText.text + $" {points}";
            lastTimePoints.text = lastTimePoints.text + $"{database.ReadFile()}";
            database.WriteFile(points);
            // timer.GetComponent<Timer>().StopTimer();
            // playTime.text = playTime.text + timer.GetComponent<Timer>().StopTimer();
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}