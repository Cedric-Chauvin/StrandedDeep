using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFloor : MonoBehaviour
{
    private PlayerController player;
    private bool playerOnWood = false;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerOnWood)
        {
            playerOnWood = true;
            player.stepId = 0;
            player.activeStepsClips = player.woodStepsClips;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerOnWood)
        {
            playerOnWood = false;
            player.stepId = 0;
            player.activeStepsClips = player.metalStepsClips;
        }
    }
}
