using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : Event
{
    [SerializeField][TextArea]
    private string text;
    public  float extraTime;

    public override string BuildGameObjectName()
    {
        return "Dialogue Box";
    }

    public override void LaunchEvent()
    {
        DialogueBoxController.Instance.SingleDialogue(text,extraTime);
    }
}
