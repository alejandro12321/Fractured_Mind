using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;

    private void Start()
    {
        prompt = "Some magic spell won’t let you out the Dark Forest.";
    }

    public bool interact(Interactor interactor)
    {
        return true;
    }
}
