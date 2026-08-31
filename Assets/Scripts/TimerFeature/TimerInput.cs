using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerInput : MonoBehaviour
{
    [SerializeField] private float _maxtime;
    private Timer _timer;

    public Timer Timer => _timer;

    private void Awake()
    {
        _timer = new Timer(_maxtime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _timer.StartTimer();

        if (Input.GetKeyDown(KeyCode.Alpha2) || (_timer.CurrentTime < 0))
            _timer.StopTimer();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _timer.RestartTimer();

        _timer.Update();
    }
}
