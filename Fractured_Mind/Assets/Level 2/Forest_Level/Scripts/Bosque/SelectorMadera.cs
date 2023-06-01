using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorMadera : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private int maderaNecesaria;
    [SerializeField] private string prompt;
    [SerializeField] private GameObject puente;
    /*
     Tipos de madera:
        1 -> Arbol Anaranjado
        2 -> Arbol Pino
        3 -> Arbol Ciruelas
        4 -> Arbol Peras
        5 -> Tronco
     */
    public string interactionPrompt => prompt;

    // Start is called before the first frame update
    void Start()
    {
        maderaNecesaria = Random.Range(1,6);
        
        if (maderaNecesaria == 1)
            prompt = "The Orange Tree has caught my eye.";
        else if (maderaNecesaria == 2)
            prompt = "Pine trees are tall enough.";
        else if (maderaNecesaria == 3)
            prompt = "Plum trees are better here.";
        else if (maderaNecesaria == 4)
            prompt = "¿Got a Pear, mate?";
        else if (maderaNecesaria == 5)
            prompt = "¡A Log might come in handy!";
        
        StartCoroutine(CheckBridgeStatus());
    }

    IEnumerator CheckBridgeStatus()
    {
        while (true)
        {
            if (puente.activeSelf)
            {
                prompt = "Bridge fixed."; // Replace with the name of the component that displays the prompt text
                break;
            }
            yield return null;
        }
    }

    public int Madera
    {
        get { return maderaNecesaria; }
        set { maderaNecesaria = value; }
    }

    public bool interact(Interactor interactor)
    {
        return true;
    }
}
