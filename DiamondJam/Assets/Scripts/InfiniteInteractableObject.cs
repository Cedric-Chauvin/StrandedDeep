using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteInteractableObject : InteractableObject
{

    [SerializeField]
    private float duration;

    private Animation myAnimation;

    protected override void Activate()
    {
        myAnimation.Play();
        IsInteractable = false;
        Invoke("SetInteractable", duration);
    }

    void Awake()
    {
        myAnimation = GetComponent<Animation>();
    }

    private void SetInteractable()
    {
        IsInteractable = true;
    }
}
