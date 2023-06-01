using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceInteractable 
{
    public string interactionPrompt { get; }

    public bool interact(Interactor interactor);
}
