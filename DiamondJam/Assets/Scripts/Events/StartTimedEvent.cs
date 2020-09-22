using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimedEvent : Event
{
    [SerializeField]
    private string name;
    [SerializeField]
    private List<TimerController.TimedEvent> timedEvents = new List<TimerController.TimedEvent>();

    public override string BuildGameObjectName()
    {
        return "TimedEvent " + name + " with " + timedEvents.Count + " events";
    }

    public override void LaunchEvent()
    {
        TimerController.Instance.LaunchRoutine(name, timedEvents);
    }

    private void Start()
    {
        type = EventType.STARTTIMED;
        timeControl = false;
    }
}
