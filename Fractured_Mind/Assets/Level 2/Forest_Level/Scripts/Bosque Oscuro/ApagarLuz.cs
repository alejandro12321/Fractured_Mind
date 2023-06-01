using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarLuz : MonoBehaviour
{
    public Light directionalLight; // Drag and drop the Directional Light game object here in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the tag of your player character
        {
            directionalLight.enabled = false; // Turn off the light
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the tag of your player character
        {
            directionalLight.enabled = true; // Turn off the light
        }
    }
}
