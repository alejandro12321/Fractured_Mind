using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string[] prompts;
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    [SerializeField] private int interactions;

    private void Start()
    {
        prompts = new string[6];
        prompts[0] = "¿Have you seen anything strange on the terrain?\n¡Explore!";
        prompts[1] = "It's 123 I think.\nFollow the arrow.";
        prompts[2] = "Mystery Objects near the river are the 2 keys to escape.";
        prompts[3] = "I have no more clues."; 
        prompts[4] = "Go where there’s no trees, on top of the hill.";
        prompts[5] = "You need the keys to Enter the Code.";
        interactions = 0;
        StartCoroutine(CambiarPrompt());
    }

    private void gen()
    {
        if (interactions >= prompts.Length)
            interactions = 0;
        prompt = prompts[interactions];
        interactions++;
    }

    IEnumerator CambiarPrompt()
    {
        while (true)
        {
            gen();
            yield return new WaitForSeconds(5);
        }
    }

    public bool interact(Interactor interactor)
    {
        gen();
        return true;
    }
}
