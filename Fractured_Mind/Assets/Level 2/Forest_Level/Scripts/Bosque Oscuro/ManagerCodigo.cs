using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCodigo : MonoBehaviour
{
    public List<GameObject> targets;
    [SerializeField] private GameObject bloqueo;
    public GameObject ManagerArbolDeLaVida;
    void Start()
    {
        bloqueo = GameObject.Find("Salida Bosque Oscuro");
        StartCoroutine(checkCodigos());
    }
    IEnumerator checkCodigos()
    {
        while (true)
        {
            if(targets[0].GetComponent<Codigo>().DefaultPrompt == "3"
                && targets[1].GetComponent<Codigo>().DefaultPrompt == "2"
                && targets[2].GetComponent<Codigo>().DefaultPrompt == "1")
            {
                //Código correcto
                Destroy(bloqueo);
                targets[0].GetComponent<Codigo>().Interactable = false;
                targets[1].GetComponent<Codigo>().Interactable = false;
                targets[2].GetComponent<Codigo>().Interactable = false;
                yield return new WaitForSeconds(1.5f);
                targets[0].GetComponent<Codigo>().DefaultPrompt = "The dark magic faded away";
                targets[1].GetComponent<Codigo>().DefaultPrompt = "The dark magic faded away";
                targets[2].GetComponent<Codigo>().DefaultPrompt = "The dark magic faded away";
                yield return new WaitForSeconds(3f);
                ManagerArbolDeLaVida.GetComponent<ManagerArbolDeLaVida>().Checkear();
                break;
            }
            yield return null;
        }
    }
}
