using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveEvent : Event
{
    public bool active;
    public GameObject gameObject;

    public override string BuildGameObjectName()
    {
        return active ? "active" : "desactive" + gameObject;
    }

    public override void LaunchEvent()
    {
        gameObject.SetActive(active);
    }

}
