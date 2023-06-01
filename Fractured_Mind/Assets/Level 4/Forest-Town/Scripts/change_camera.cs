using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_camera : MonoBehaviour
{
    public Camera camera1; // Referencia a la primera cámara
    public Camera camera2; // Referencia a la segunda cámara

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactivar la primera cámara y activar la segunda cámara
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
    }
}
