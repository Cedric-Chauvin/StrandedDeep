using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : Event
{
    public InteractableObject interactableObject;
    void Start()
    {
        type = EventType.INTERACTION;
    }

    public override string BuildGameObjectName()
    {
        return "Interaction(" + interactableObject.gameObject.name + ")";
    }

    public override void LaunchEvent()
    {
        interactableObject.IsInteractable = true;
        interactableObject.OnInteract = () => 
        {
            EventSequencer.Instance.NextEvent();
            interactableObject.OnInteract = null;
        };
    }
}
