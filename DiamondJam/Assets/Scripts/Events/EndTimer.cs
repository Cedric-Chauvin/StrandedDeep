using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimer : Event
{
    public string name;

    public override string BuildGameObjectName()
    {
        return "EndTimer " + name;
    }

    public override void LaunchEvent()
    {
        TimerController.Instance.StopCoroutineInProcess(name);
    }
}
