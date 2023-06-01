using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolPino : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Pine";
    }
    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        inventario.Madera = 2;
        return true;
    }
}
