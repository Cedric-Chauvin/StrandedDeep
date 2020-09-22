using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : Event
{
    public TriggerZone zone;
    private void Start()
    {
        type = EventType.TRIGGERZONE;
    }

    public override string BuildGameObjectName()
    {
        return "TriggerZone(" + zone.gameObject.name + ")";
    }

    public override void LaunchEvent()
    {
        zone.canTrigger = true;
        zone.OnTrigger = () =>
        {
            zone.OnTrigger = null;
            EventSequencer.Instance.NextEvent();
        };
    }
}
