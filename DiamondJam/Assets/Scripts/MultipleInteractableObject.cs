using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInteractableObject : InfiniteInteractableObject
{
    [SerializeField]
    private List<AudioSource> audioSources;

    protected override void Activate()
    {
        events[0].LaunchEvent();
        audioSources[0].Play();
        if (events.Count > 1)
        {
            events.RemoveAt(0);
            audioSources.RemoveAt(0);
        }
        IsInteractable = false;
        Invoke("SetInteractable", duration);
    }
}
