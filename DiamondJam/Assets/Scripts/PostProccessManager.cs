using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProccessManager : MonoBehaviour
{
    private static PostProccessManager _instance = null;
    public static PostProccessManager Instance
    {
        get { return _instance; }
    }
    private Animator anim;
    public enum STATE
    {
        NORMAL,
        VYPED,
        PRESSION,
        CRAZY1,
        CRAZY2,
        CRAZY3
    }

    public STATE mentalState = STATE.NORMAL;
    public bool normalState = true;
    public float timer = 0.0f;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }
        else
            _instance = this;

        anim = GetComponent<Animator>();
    }

    public void ChangeState(STATE state, float time)
    {
        timer = time;
        mentalState = state;
    }

    private void Update()
    {
        if(mentalState != STATE.NORMAL)
        {
            anim.SetInteger("mentalState", (int)mentalState);
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                mentalState = STATE.NORMAL;
                anim.SetInteger("mentalState", (int)mentalState);
            }
        }
    }
}
