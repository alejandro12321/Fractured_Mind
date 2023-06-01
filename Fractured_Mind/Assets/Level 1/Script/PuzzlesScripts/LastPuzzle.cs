using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPuzzle : MonoBehaviour
{
    public GameObject talkPanel, hintPanel, puzzlePanel;

    public int chanceLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateLastPuzzle()
    {
        talkPanel.SetActive(true);
    }


}
