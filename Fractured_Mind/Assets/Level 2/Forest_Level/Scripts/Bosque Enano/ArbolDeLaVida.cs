using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolDeLaVida : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Tree of Life";
    }
    public bool interact(Interactor interactor)
    {
        return true;
    }
}
