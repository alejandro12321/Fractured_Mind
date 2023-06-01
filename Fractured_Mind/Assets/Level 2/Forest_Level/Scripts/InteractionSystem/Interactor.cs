using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.25f;
    [SerializeField] private LayerMask interactableMask;
    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int collidersFound;
    [SerializeField] private InteractionPromptUI interactionPromptUI; 
    private InterfaceInteractable interactuable;

    private void Update()
    {
        collidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if(collidersFound > 0)
        {
            interactuable = colliders[0].GetComponent<InterfaceInteractable>();

            if (interactuable != null )
            {
                interactionPromptUI.setUpPrompt(interactuable.interactionPrompt);
                if (Input.GetKeyDown(KeyCode.E))
                    interactuable.interact(this);
            }
        }
        else
        {
            if (interactuable != null)
                interactuable = null;
            if (interactionPromptUI.isDisplayed)
                interactionPromptUI.closePrompt();
        }
    }
}
