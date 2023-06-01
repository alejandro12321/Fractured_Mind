


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public TextMeshProUGUI mensajeTexto; 
    public GameObject dialogCanvas; 
    public string message;
    private GameObject player;
    
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OcultarMensaje();
            
        }
    }

    private void OcultarMensaje()
    {
        mensajeTexto.gameObject.SetActive(false);
        dialogCanvas.gameObject.SetActive(false);
        dialogCanvas.GetComponent<Canvas>().enabled = false;
    }
    
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        if (player != null)
        {
            Animator animator = player.GetComponent<Animator>();
            if (animator != null)
            {
                // Activar la animación "isDie"
                animator.SetBool("isDie", true);
            }
        }

        MostrarMensaje();

        float tiempoEspera = 5f;
        StartCoroutine(CargarEscenaDespuesDeEspera(tiempoEspera));
    }
}
    
   private IEnumerator CargarEscenaDespuesDeEspera(float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene("Credits");
    }

    private void MostrarMensaje()
    {
        
        dialogCanvas.gameObject.SetActive(true);
        dialogCanvas.GetComponent<Canvas>().enabled = true;
        mensajeTexto.gameObject.SetActive(true);
        mensajeTexto.text = message;
    }
}
