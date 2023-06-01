using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreHousePuzzle : MonoBehaviour
{
    public TextMeshProUGUI goldenKey, silverKey, rustyKey;
    public GameObject completePanel, optionPanel, wrongSelected;
    public bool golden, silver, rusty, riddlesActive;

    public bool isPuzzleActive;

    private void Start() {
        isPuzzleActive = true;
    }
    
    void Update()
    {
        if (golden && silver && rusty)
        {
            completePanel.SetActive(true);
            riddlesActive = true;
        }
    }

    public void findKeys(string nameObject)
    {
        if (nameObject == "Key_Silver" && golden == false)
        {
            goldenKey.text = "1";
            golden = true;
        }
        if (nameObject == "Key_Rusty" && silver == false)
        {
            silverKey.text = "1";
            silver = true;
        }
        if (nameObject == "Key_Golden" && rusty == false)
        {
            rustyKey.text = "1";
            rusty = true;
        }
    }

    public void wrongAnswer()
    {
        wrongSelected.SetActive(true);  
    }

    public void goodAnswere()
    {
        isPuzzleActive = false;
        DeactivateSelection();
    }

    public void ActivateSelection()
    {
        optionPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void DeactivateSelection()
    {
        optionPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
