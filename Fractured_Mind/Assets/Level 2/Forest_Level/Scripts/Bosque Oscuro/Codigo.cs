using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigo : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string defaultPrompt;
    public string interactionPrompt => defaultPrompt;
    [SerializeField] private string[] prompts;
    [SerializeField] private int interactions;
    private bool interactable;
    private void Start()
    {
        interactable = true;
        interactions = 0;
        prompts = new string[] { "1", "2", "3" };
    }
    public bool interact(Interactor interactor)
    {
        if (!interactable)
            return false;
        int inventario = interactor.GetComponent<Inventario>().ObjetoMisterioso;      //Objetos misteriosos en inventario
        if(inventario == 2)
        {
            if (interactions >= prompts.Length)
                interactions = 0;
            defaultPrompt = prompts[interactions];
            interactions++;
        }
        return true;
    }
    public string DefaultPrompt
    {
        get { return defaultPrompt; }
        set { defaultPrompt = value; }
    }
    public bool Interactable
    {
        get { return interactable; }
        set { interactable = value; }
    }
}
