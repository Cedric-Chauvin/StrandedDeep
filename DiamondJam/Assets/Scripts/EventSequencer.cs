using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequencer : MonoBehaviour
{
    #region Singleton
    private static EventSequencer _instance = null;
    public static EventSequencer Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            _instance = this;
    }
    #endregion

    private Event[] _events;
    public Event[] events
    {
        get { return _events; }
        set { _events = value; }
    }

    private Event _activeEvent;
    private int _eventId;
    private float _eventTimer;

    void Start()
    {
        _events = GetComponentsInChildren<Event>();
        _eventId = 0;
        _activeEvent = _events[_eventId];
        StartEvent();
    }

    private void Update()
    {
        GameLoop();
    }

    public void GameLoop()
    {
        _eventTimer += Time.deltaTime;
        if (_eventTimer >= _activeEvent.duration && _activeEvent.timeControl)
        {
                NextEvent();
        }
    }

    public void StartEvent()
    {
        _activeEvent = _events[_eventId];
        _activeEvent.LaunchEvent();
    }

    public void NextEvent()
    {
        _eventTimer = 0;
        if(_eventId < _events.Length - 1)
        {
            _eventId++;
            StartEvent();
        }
    }

}
