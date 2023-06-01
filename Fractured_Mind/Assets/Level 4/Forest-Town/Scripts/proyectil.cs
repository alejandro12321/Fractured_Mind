using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    public float distanciaMaxima = 10f;
    public float velocidad = 10f;

    private Vector3 posicionInicial;
    private Vector3 posicionAnterior;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        posicionAnterior = posicionInicial;
    }

    private void Update()
    {
        float distancia = Vector3.Distance(posicionInicial, transform.position);

        if (distancia >= distanciaMaxima)
        {
            Destroy(gameObject);
        }

        // Actualizar el collider
        Vector3 desplazamiento = transform.position - posicionAnterior;
        transform.position += desplazamiento;
        posicionAnterior = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 direccion = (transform.position - posicionInicial).normalized;
        rb.velocity = direccion * velocidad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
