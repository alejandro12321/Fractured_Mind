using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_impact : MonoBehaviour
{
    public int vida = 3; // Valor de vida predeterminado para impactos normales

    // Si se trata de un boss, cambia el valor de vida a 20 en el inspector
    // para que los impactos tengan un efecto diferente
    public bool esBoss = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("arrow"))
        {
            Debug.Log("Impacto de flecha");
            vida--; // Reduce la vida en 1 al colisionar con una flecha

            if (vida <= 0)
            {
                // Si la vida llega a 0 o menos, realiza acciones adicionales o destruye el objeto
                if (esBoss)
                {
                    // Acciones para un boss cuando su vida llega a 0
                }
                else
                {
                    // Acciones para un impacto normal cuando su vida llega a 0
                }

                Destroy(gameObject); // Destruye el objeto actual
            }
        }
    }

    private void Start()
    {
        if (esBoss)
        {
            vida = 20; // Asigna 20 de vida si es un boss
        }
    }
}
