using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteInteractableObject : InteractableObject
{
    [SerializeField]
    protected List<Event> events = new List<Event>();
    [SerializeField]
    protected float duration;

    private Animation myAnimation;

    protected override void Activate()
    {
        if (IsInvoking())
            { IsInteractable = false; return; }
        myAnimation.Play();
        IsInteractable = false;
        Invoke("SetInteractable", duration);
        if (OnInteract != null)
            OnInteract.Invoke();

        foreach (var item in events)   
        {  
            item.LaunchEvent();
        }
    }

    void Awake()
    {
        myAnimation = GetComponent<Animation>();
    }

    protected void SetInteractable()
    {
        IsInteractable = true;
    }
}
