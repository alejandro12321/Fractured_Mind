using UnityEngine;
using System.Collections;

public class attack_arrow : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 10f;
    public float delayEntreDisparos = 1.0f;

    private float tiempoUltimoDisparo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time - tiempoUltimoDisparo >= delayEntreDisparos)
            {
                StartCoroutine(Disparar());
                tiempoUltimoDisparo = Time.time;
            }
        }
    }
    
    private IEnumerator Disparar()
    {
        Debug.Log("Disparando");
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);

        // Aplicar rotación adicional en el eje X
        proyectil.transform.Rotate(Vector3.right, 90f);

        // Esperar un tiempo antes de permitir el siguiente disparo
        yield return new WaitForSeconds(delayEntreDisparos);

        // Verificar si el objeto proyectil aún existe
        if (proyectil != null)
        {
            // Restaurar la rotación original del proyectil si es necesario
            proyectil.transform.rotation = puntoDisparo.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("ObjetoX"))
        //{
        //    Destroy(other.gameObject);
        //}
    }
}

