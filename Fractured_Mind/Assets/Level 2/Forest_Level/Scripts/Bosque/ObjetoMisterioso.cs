using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMisterioso : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private bool interacted;
    public string interactionPrompt => prompt;
    private void Start()
    {
        prompt = "???";
        interacted = false;
    }

    private void Update()
    {
        if (prompt == "Key Found!")
        {
            StartCoroutine(CambiarPrompt());
        }
    }

    IEnumerator CambiarPrompt()
    {
        yield return new WaitForSeconds(5);
        prompt = "???";
    }

    public bool interact(Interactor interactor)
    {
        var inventario = interactor.GetComponent<Inventario>();
        if (!interacted)
        {
            prompt = "Key Found!";
            inventario.ObjetoMisterioso++;
            interacted = true;
        }
        return true;
    }
}
