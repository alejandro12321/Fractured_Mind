using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Log";
    }
    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        inventario.Madera = 5;
        return true;
    }
}
