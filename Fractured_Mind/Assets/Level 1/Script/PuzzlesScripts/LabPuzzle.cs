using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabPuzzle : MonoBehaviour
{
    public TextMeshProUGUI potionObject, dogPotionObject, driedObject;
    public GameObject dragPanel, recipePanel, doorPotionPanel;
    public bool potion, dogPotion, dried, fullObjects;
    public DropSlot slot1, slot2, slot3;

    public bool isPuzzleActive;

    // Start is called before the first frame update
    void Start()
    {
        isPuzzleActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (potion && dogPotion && dried)
        {
            fullObjects = true;
        }
        levelComplete();
    }

    public void levelComplete()
    {
        if (slot1.passLevel && slot2.passLevel && slot3.passLevel)
        {
            isPuzzleActive = false;
            DeactivateRecipe();
            doorPotionPanel.SetActive(true);
        }
    }

    public void findObjects(string nameObject)
    {
        if (nameObject == "Potion" && potion == false)
        {
            potionObject.text = "1";
            potion = true;
        }
        if (nameObject == "dogPotion" && dogPotion == false)
        {
            dogPotionObject.text = "1";
            dogPotion = true;
        }
        if (nameObject == "driedBag" && dried == false)
        {
            driedObject.text = "1";
            dried = true;
        }
    }

    public void ActivateSelection()
    {
        dragPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void DeactivateSelection()
    {
        dragPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ActivateRecipe()
    {
        recipePanel.SetActive(true);
    }

    public void DeactivateRecipe()
    {
        recipePanel.SetActive(false);
    }
}
