using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Button buttonConcentration;
    [SerializeField] Button buttonColourFeed;
    [SerializeField] private string concentration = "Concentration";
    [SerializeField] private string colourFeed = "ColourFeed";
    // Start is called before the first frame update
    void Start()
    {
        buttonConcentration.onClick.AddListener(delegate{LoadSelection(ref concentration);});
        buttonColourFeed.onClick.AddListener(delegate{LoadSelection(ref colourFeed);});
    }

    private void LoadSelection(ref string selection)
    {
        SceneManager.LoadScene(selection, LoadSceneMode.Single);
    }
}
