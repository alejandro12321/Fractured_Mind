using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sigilo : MonoBehaviour
{
    public float velocidadNormal = 5f;
    public float velocidadSigilo = 2f;

    private float velocidadActual;

    private void Start()
    {
        velocidadActual = velocidadNormal;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            velocidadActual = velocidadSigilo;
        }
        else
        {
            velocidadActual = velocidadNormal;
        }

        // Mover el personaje con la velocidad actual
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidadActual;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadActual;
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * Time.deltaTime;
        transform.Translate(movimiento);
    }
}