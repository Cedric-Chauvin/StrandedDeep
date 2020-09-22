using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool canTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canTrigger)
        {
            canTrigger = false;
            EventSequencer.Instance.NextEvent();
        }
    }
}
