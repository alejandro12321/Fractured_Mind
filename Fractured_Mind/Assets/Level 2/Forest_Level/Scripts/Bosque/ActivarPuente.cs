using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuente : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private int interacciones;
    public GameObject puente;
    public string interactionPrompt => prompt;

    private void Start()
    {
        interacciones = 0;
        prompt = "Collect the correct wood to fix the bridge.\nPress E here when you get the wood.";
        StartCoroutine(repararPuente());
    }
    IEnumerator repararPuente()
    {
        while (true)
        {
            if(interacciones == 1)
                prompt = "Need more wood.";
            else if(interacciones == 2)
                prompt = "Need just one more piece of wood.";
            else if (interacciones == 3)
            {
                prompt = "You've repaired the bridge...\nGood Luck!";
                if (puente != null)
                {                    
                    puente.gameObject.SetActive(true);
                    yield return new WaitForSeconds(2f);
                    Destroy(GameObject.FindGameObjectWithTag("BloqueoPuente"));   
                }
                break;
            }
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before checking again
        }
    }

    public bool interact(Interactor interactor)
    {
        int inventario = interactor.GetComponent<Inventario>().Madera;      //Madera en inventario

        GameObject letrero = GameObject.FindGameObjectWithTag("LetreroSelectorMadera");
        int maderaNecesaria = letrero.GetComponent<SelectorMadera>().Madera;//Madera necesaria para reparar puente

        switch (inventario)
        {
            case 1:
                if (inventario == maderaNecesaria)
                {
                    inventario = -1;
                    interacciones++;
                    interactor.GetComponent<Inventario>().Madera = 0;
                    return true;
                }
                break;

            case 2:
                if (inventario == maderaNecesaria)
                {
                    inventario = -1;
                    interacciones++;
                    interactor.GetComponent<Inventario>().Madera = 0;
                    return true;
                }
                break;

            case 3:
                if (inventario == maderaNecesaria)
                {
                    inventario = -1;
                    interacciones++;
                    interactor.GetComponent<Inventario>().Madera = 0;
                    return true;
                }
                break;

            case 4:
                if (inventario == maderaNecesaria)
                {
                    inventario = -1;
                    interacciones++;
                    interactor.GetComponent<Inventario>().Madera = 0;
                    return true;
                }
                break;

            case 5:
                if (inventario == maderaNecesaria)
                {
                    inventario = -1;
                    interacciones++;
                    interactor.GetComponent<Inventario>().Madera = 0;
                    return true;
                }
                break;

            default:
                Debug.Log("No se encontró madera en el inventario");
                break;
        }
        interactor.GetComponent<Inventario>().Madera = 0;
        return false;
    }
}
