using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolAnaranjado : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "Orange Tree";
    }
    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        inventario.Madera = 1;
        return true;
    }
}
