using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessEvent : Event
{
    public PostProccessManager.STATE state;
    public float time;

    public override string BuildGameObjectName()
    {
        return "PostProcess Set " + state.ToString() + time + "second"; 
    }

    public override void LaunchEvent()
    {
        PostProccessManager.Instance.ChangeState(state, time);
    }
}
