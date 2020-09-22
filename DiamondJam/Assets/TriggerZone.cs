using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private List<Event> events = new List<Event>();

    public Action OnTrigger;

    public bool canTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canTrigger)
        {
            canTrigger = false;
            if (OnTrigger != null)
                OnTrigger.Invoke();

            foreach (var item in events)
            {
                item.LaunchEvent();
            }
        }
    }
}
