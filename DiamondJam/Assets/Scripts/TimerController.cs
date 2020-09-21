using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    #region Singleton

    private static TimerController instance;

    public static TimerController Instance { get => instance; }
    #endregion

    private Dictionary<string, Coroutine> CoroutineInProcess = new Dictionary<string, Coroutine>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
    }

    public void StopCoroutineInProcess(string name)
    {
        if (CoroutineInProcess.ContainsKey(name))
        {
            StopCoroutine(CoroutineInProcess[name]);
            CoroutineInProcess.Remove(name);
        }
        else
            Debug.LogError(name + "is not runing or doesn't exist");
    }

    public void LaunchRoutine(string name, List<TimedEvent> events)
    {
        events.Sort(Comparison);
        if (CoroutineInProcess.ContainsKey(name))
            StopCoroutineInProcess(name);
        CoroutineInProcess.Add(name, StartCoroutine(TimerRoutine(name, events)));
    }

    private IEnumerator TimerRoutine(string name, List<TimedEvent> events)
    {
        float timer = 0;
        while (events.Count > 0)
        {
            if(timer >= events[0].time)
            {
                events[0].evenement.Invoke();
                events.RemoveAt(0);
            }
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        CoroutineInProcess.Remove(name);
    }

    [Serializable]
    public class TimedEvent
    {
        public TimedEvent(float time, Action action)
        {
            this.time = time;
            evenement = action;
        }

        public float time;
        public Action evenement;
    }

    private int Comparison(TimedEvent x, TimedEvent y)
    {
        float dif = x.time - y.time;
        if (dif == 0)
            return 0;
        if (dif > 0)
            return 1;
        else
            return -1;
    }
}
