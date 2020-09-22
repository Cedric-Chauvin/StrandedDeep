using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInteractionObject : InteractableObject
{
    [SerializeField]
    private List<Event> events = new List<Event>();

    private void Start()
    {
        IsInteractable = false;
    }
    protected override void Activate()
    {
        IsInteractable = false;
        if (OnInteract != null)
            OnInteract.Invoke();
        foreach (Event item in events)
        {
            item.LaunchEvent();
        }
    }
}
