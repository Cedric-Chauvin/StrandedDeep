using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event : MonoBehaviour
{
    public enum EventType
    {
        SOUND,
        TRIGGERZONE,
        TEXT,
        BLANK
    }
    protected EventType type;
    public float duration;
    public bool timeControl = false;
    public abstract void LaunchEvent();
    public abstract string BuildGameObjectName();
    private void OnValidate()
    {
        gameObject.name = BuildGameObjectName();
    }
    public EventType GetPhaseType()
    {
        return type;
    }
}
