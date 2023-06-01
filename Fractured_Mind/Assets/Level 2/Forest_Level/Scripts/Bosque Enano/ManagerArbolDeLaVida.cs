using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerArbolDeLaVida : MonoBehaviour
{
    public GameObject player, arbol, hongo, salida;
    [SerializeField] private int maderaEnInventario, maderaArbolDeLaVida;
    void Start()
    {
        maderaArbolDeLaVida = Random.Range(1, 6);
    }
    public void Checkear()
    {
        StartCoroutine(CheckArbolDeLaVida());
    }
    IEnumerator CheckArbolDeLaVida()
    {
        while (true)
        {
            maderaEnInventario = player.GetComponent<Inventario>().Madera;
            if (maderaEnInventario > 0)
                break;
            yield return null;
        }

        if(maderaArbolDeLaVida == maderaEnInventario)
        {
            //Aparece árbol de la vida
            arbol.SetActive(true);
            hongo.SetActive(false);
            GameObject randomPrefab = arbol.transform.GetChild(maderaArbolDeLaVida-1).gameObject;
            randomPrefab.SetActive(true);
            player.GetComponent<Inventario>().Madera = 0;
            salida.SetActive(true);
        }
        else
        {
            //Aparece hongo
            hongo.SetActive(true);
            yield return new WaitForSeconds(3f);
            hongo.GetComponent<MoverHongo>().StartMoving();
        } 
    }
}
