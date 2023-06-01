using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private int tieneMadera;
    [SerializeField] private int objetoMisterioso;
    [SerializeField] private GameObject woodIcon;
    /*
     Tipos de madera:
        1 -> Arbol Anaranjado
        2 -> Arbol Pino
        3 -> Arbol Ciruelas
        4 -> Arbol Peras
        5 -> Tronco
     */
    private void Start()
    {
        this.tieneMadera = 0;
        this.objetoMisterioso = 0;
        StartCoroutine(MostrarIconoMadera());
        StartCoroutine(TirarMadera());
    }
    public int Madera
    {
        get { return tieneMadera; }
        set { tieneMadera = value; }
    }
    public int ObjetoMisterioso
    {
        get { return objetoMisterioso; }
        set { objetoMisterioso = value; }
    }
    private IEnumerator MostrarIconoMadera()
    {
        while (true)
        {
            if (tieneMadera > 0)
                woodIcon.SetActive(true);
            else
                woodIcon.SetActive(false);
            yield return null;
        }
    }
    private IEnumerator TirarMadera()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R)) 
                tieneMadera = 0;
            yield return null;
        }
    }
}
