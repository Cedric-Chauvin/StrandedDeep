using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEvent : Event
{
    public float slowDuration;
    public float movementSlowAmount;
    public float cameraSlowAmount;
    private PlayerController player;
    private CameraMouseController cam;
    private float playerSpeed;
    private float playerStepsSpeed;
    private float cameraSpeed;
    private bool isLaunched = false;
    private bool isEnded = false;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraMouseController>();
        playerSpeed = player.speed;
        cameraSpeed = cam.sensitivity;
        playerStepsSpeed = player.timeBetweenSteps;
        timeControl = true;
    }
    public override string BuildGameObjectName()
    {
        return "Slow Event " + "(" + slowDuration + "s)";
    }

    public override void LaunchEvent()
    {
        player.speed -= movementSlowAmount;
        player.timeBetweenSteps = 1;
        cam.sensitivity -= cameraSlowAmount;
        isLaunched = true;
    }

    private void Update()
    {
        if(isLaunched && !isEnded)
        {
            slowDuration -= Time.deltaTime;
            if(slowDuration <= 0)
            {
                isEnded = true;
                player.speed = playerSpeed;
                player.timeBetweenSteps = playerStepsSpeed;
                cam.sensitivity = cameraSpeed;
            }
        }
    }
}
