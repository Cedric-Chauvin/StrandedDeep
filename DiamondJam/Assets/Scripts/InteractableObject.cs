using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour
{
    private bool isInteractable = true;

    public bool IsInteractable
    {
        get => isInteractable;
        set
        {
            fill.fillAmount = 0;
            fill.gameObject.SetActive(value && playerInZone);
            isInteractable = value;
        }
    }

    [SerializeField]
    private float inputDuration;
    [SerializeField]
    private Image fill;

    private float duration;
    private bool playerInZone;
    
    protected abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isInteractable)
        {
            fill.gameObject.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isInteractable && other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (duration >= inputDuration)
                    Activate();
                else
                    duration += Time.deltaTime;
                fill.fillAmount = duration;
            }else if (duration != 0)
            {
                duration = 0;
                fill.fillAmount = duration;
            }
        }

        Debug.Log("trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fill.gameObject.SetActive(false);
            playerInZone = false;
            duration = 0;
            fill.fillAmount = duration;
        }
    }

}
