using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankEvent : Event
{
    private void Start()
    {
        type = EventType.BLANK; 
    }

    public override string BuildGameObjectName()
    {
        return "Blank(" + duration + "s)";
    }

    public override void LaunchEvent()
    {
        timeControl = true;
    }
}
