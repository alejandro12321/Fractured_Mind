using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolCiruelas : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Plum";
    }
    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        inventario.Madera = 3;
        return true;
    }
}
