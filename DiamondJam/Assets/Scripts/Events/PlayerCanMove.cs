using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanMove : Event
{
    public bool active;
    public PlayerController controller;
    public override string BuildGameObjectName()
    {
        return (active ? "active" : "desactive") + " playerMovement";
    }

    public override void LaunchEvent()
    {
        controller.canMove = active;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeControl = true;
    }
}
