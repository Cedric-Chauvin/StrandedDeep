using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEvent : Event
{
    [Header("Fade Parameter")]
    [SerializeField]
    private bool activeFade;
    private void Start()
    {
        timeControl = false;
    }
    public override string BuildGameObjectName()
    {
        if (activeFade)
            return "Active Fade";
        else
            return "Desactive Fade";
    }

    public override void LaunchEvent()
    {    
        UIManager.Instance.FadeChange(activeFade);
    }
}
