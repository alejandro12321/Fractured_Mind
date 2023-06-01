using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letrero : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;

    public void Start()
    {
        this.prompt = "Press E to collect wood from trees.\nPress R to discard wood from inventory.";
    }

    public bool interact(Interactor interactor)
    {
        return true;
    }
}
