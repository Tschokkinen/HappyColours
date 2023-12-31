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
        public GameObject activeGO;
        [SerializeField] private GameObject[] squares;
        SpriteRenderer spriteRenderer;
        [SerializeField] private int points;
        Coroutine coroutine;

        [SerializeField] Button button;
        [SerializeField] GameObject panel;
        [SerializeField] TMP_Text pointText;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ChangeColor());
            coroutine = null;

            button.onClick.AddListener(BackToMain);
            panel.SetActive(false);
        }

        IEnumerator ChangeColor()
        {
            while (true)
            {
                GameObject square = GetNextSquare();
                yield return new WaitForSeconds(2.0f);

                square.GetComponent<Square>().SetActiveStatus();
                activeGO = square;
                SetInactive();
            }
        }

        GameObject GetNextSquare()
        {
            float val = Random.Range(0.0f, 100.0f);
            if (val < 25.0f) return squares[0];
            if (val < 50.0f && val > 25.0f) return squares[1];
            if (val < 75.0f && val > 50.0f) return squares[2];
            if (val > 75.0f) return squares[3];
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

        IEnumerator IncrementPoints()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                points += 1;
                Debug.Log($"Points: {points}");
            }
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
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}