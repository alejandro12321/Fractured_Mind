using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class go_to_mountain : MonoBehaviour
{
    public string nombreEscenaDestino; 
    public TextMeshProUGUI mensajeTexto; 
    public GameObject dialogCanvas; 

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
    private void MostrarMensaje()
    {
        
        dialogCanvas.gameObject.SetActive(true);
        dialogCanvas.GetComponent<Canvas>().enabled = true;
        mensajeTexto.gameObject.SetActive(true);
        mensajeTexto.text = "You need to collect 20 steaks";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int score = GameManager.instance.score;
            
            if (score > 20)
            {
                // Desactivar este objeto
                gameObject.SetActive(false);
                 // Cargar la escena destino
                SceneManager.LoadScene(nombreEscenaDestino);
            }
            else
            {
                // Mostrar un mensaje 
                MostrarMensaje();
                Debug.Log("El puntaje es menor a 20. Mostrar mensaje aquí.");
            }


        }
    }
}
