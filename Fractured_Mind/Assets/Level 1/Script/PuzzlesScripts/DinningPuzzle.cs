using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinningPuzzle : MonoBehaviour
{
    public bool isPuzzleActive;
    public TextMeshProUGUI textHint;
    public TextMeshProUGUI textFound;
    // Start is called before the first frame update
    void Start()
    {
        isPuzzleActive = true;
        textHint.text = "";
        textFound.text = "Location unknown";
    }

    public void activePuzzle ()
    {
        textHint.text = "I should investigate the dining room, to find the key I need...";
    }

    public void keyFound ()
    {
        textHint.text = "This is the key I need, although it's a bit sticky.";
        textFound.text = "Key found";
        isPuzzleActive = false;
    }

    public void confusePlayer(string nameObject)
    {
        if (nameObject == "Throne" )
        {
            textHint.text = "Near the throne there is nothing more than a strong smell of alcohol ..";
        }
        if (nameObject == "Carpet" )
        {
            textHint.text = "This old carpet hides nothing but dust..";
        }
        if (nameObject == "Barrel" )
        {
            textHint.text = "Empty barrel, it was to be expected..";
        }
        if (nameObject == "Table" )
        {
            textHint.text = "Only empty beer bottles are visible..";
        }
    }
}
