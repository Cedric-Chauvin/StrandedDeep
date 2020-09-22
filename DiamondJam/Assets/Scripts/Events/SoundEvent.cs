using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : Event
{
    [Header("Sound Event Parameters")]
    public AudioSource source;

    public override void LaunchEvent()
    {
        timeControl = true;
        source.Play();
    }
    public override string BuildGameObjectName()
    {
        return "Sound (" + source.clip.name + ")";
    }

    private void Start()
    {
        type = EventType.SOUND;
    }
}
