using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolPeras : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Pear";
    }
    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        inventario.Madera = 4;
        return true;
    }
}
