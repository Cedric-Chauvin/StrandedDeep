using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInteractionObject : InteractableObject
{
    private void Start()
    {
        IsInteractable = false;
    }
    protected override void Activate()
    {
        IsInteractable = false;
        if (OnInteract != null)
            OnInteract.Invoke();
    }
}
