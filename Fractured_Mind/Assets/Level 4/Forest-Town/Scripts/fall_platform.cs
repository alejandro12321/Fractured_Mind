using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_platform : MonoBehaviour
{
    public float tiempoCaída = 2f; // Tiempo en segundos antes de que la plataforma se caiga
    public float velocidadCaída = 2f; // Velocidad de caída de la plataforma
    public float tiempoReaparicion = 3f; // Tiempo en segundos antes de que la plataforma vuelva a aparecer

    private Vector3 posicionInicial; // Posición inicial de la plataforma
    private bool jugadorTocando = false; // Variable para verificar si el jugador está tocando la plataforma
    private bool caer = false; // Variable para controlar si la plataforma está cayendo

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorTocando = true;
            StartCoroutine(EmpezarCaida());
        }
    }

    private IEnumerator EmpezarCaida()
    {
        yield return new WaitForSeconds(tiempoCaída);
        caer = true;

        yield return new WaitForSeconds(tiempoReaparicion);
        Reaparecer();
    }

    private void Update()
    {
        if (caer)
        {
            // Mover la plataforma hacia abajo
            transform.Translate(Vector3.down * velocidadCaída * Time.deltaTime);
        }
    }

    private void Reaparecer()
    {
        caer = false;
        transform.position = posicionInicial;
    }
}
