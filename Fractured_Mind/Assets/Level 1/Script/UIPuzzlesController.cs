using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPuzzlesController : MonoBehaviour
{
    public GameObject uiPanel;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(false); 
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Reemplaza "Player" con la etiqueta del objeto que debe activar la UI
        {
            DeactivateUI();
        }
    }

    public void ActivateUI()
    {
        uiPanel.SetActive(true);
    }

    public void DeactivateUI()
    {
        uiPanel.SetActive(false);
    }
}
