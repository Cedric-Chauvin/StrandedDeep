using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private bool isInteractable = true;

    public bool IsInteractable
    {
        get => isInteractable;
        set
        {
            UIManager.Instance.InteractionFill.fillAmount = 0;
            UIManager.Instance.InteractionFill.gameObject.SetActive(value && playerInZone);
            isInteractable = value;
        }
    }

    public Action OnInteract;

    [SerializeField]
    private float inputDuration;

    private float duration;
    private bool playerInZone;
    
    protected abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isInteractable)
        {
            UIManager.Instance.InteractionFill.gameObject.SetActive(true);
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
                UIManager.Instance.InteractionFill.fillAmount = duration/inputDuration;
            }else if (duration != 0)
            {
                duration = 0;
                UIManager.Instance.InteractionFill.fillAmount = duration;
            }
        }

        Debug.Log("trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.InteractionFill.gameObject.SetActive(false);
            playerInZone = false;
            duration = 0;
            UIManager.Instance.InteractionFill.fillAmount = duration;
        }
    }

}
