using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MensajeCubo : MonoBehaviour
{
    private bool chuletasRecolectadas = false;
    public TextMeshProUGUI mensajeTexto; 
    public GameObject dialogCanvas; 
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (chuletasRecolectadas && Input.GetKeyDown(KeyCode.E))
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
                chuletasRecolectadas = true;
                MostrarMensaje();
                if(message=="GAME OVER"){
                    StartCoroutine(ResetGame());
                }
                    
            }
        }
    
   

    private void MostrarMensaje()
    {
        
        dialogCanvas.gameObject.SetActive(true);
        dialogCanvas.GetComponent<Canvas>().enabled = true;
        mensajeTexto.gameObject.SetActive(true);
        mensajeTexto.text = message;
    }
    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
