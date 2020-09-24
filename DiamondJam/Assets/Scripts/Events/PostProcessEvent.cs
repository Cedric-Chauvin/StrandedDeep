using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessEvent : Event
{
    public PostProccessManager.STATE state;
    public float time;
    private void Start()
    {
        timeControl = true;
    }
    public override string BuildGameObjectName()
    {
        return "State (" + state.ToString() + time + " s)"; 
    }

    public override void LaunchEvent()
    {
        PostProccessManager.Instance.ChangeState(state, time);
    }
}
