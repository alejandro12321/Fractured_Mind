using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaSembrarArbol : MonoBehaviour
{
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main;
        interactionPromptUI.closePrompt();
        StartCoroutine(enfocarCamara());
    }
    IEnumerator enfocarCamara()
    {
        while (true)
        {
            var rotation = mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        interactionPromptUI.setUpPrompt("Select a tree to plant the Tree of Life\nIf Fungi appears you must stop him!\nPress E to fight Fungi");
    }
    private void OnTriggerExit(Collider other)
    {
        if (interactionPromptUI.isDisplayed)
            interactionPromptUI.closePrompt();
    }
}
