using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInteractableObject : InfiniteInteractableObject
{

    protected override void Activate()
    {
        events[0].LaunchEvent();
        if (events.Count > 1)
            events.RemoveAt(0);
        IsInteractable = false;
        Invoke("SetInteractable", duration);
    }
}
