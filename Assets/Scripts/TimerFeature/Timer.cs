using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float> TimerUpdated;
    public event Action TimerRestarted;

    [SerializeField] private float _maxTime;
    private float _currentTime;
    private bool _isRunning;

    public float MaxTime => _maxTime;
    public float CurrentTime
    {
        get => _currentTime;
        private set
        {
            _currentTime = value;
            TimerUpdated?.Invoke(CurrentTime);
        }
    }

    private void Awake()
    {
        CurrentTime = _maxTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartTimer();

        if (Input.GetKeyDown(KeyCode.Alpha2) || (CurrentTime < 0))
            StopTimer();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            RestartTimer();

        if (_isRunning)
            CurrentTime -= UnityEngine.Time.deltaTime;

    }

    private void StartTimer()
    {
        if (_isRunning == false)
            _isRunning = true;
    }

    private void StopTimer()
    {
        if (_isRunning)
            _isRunning = false;
    }

    private void RestartTimer()
    {
        CurrentTime = _maxTime;
        _isRunning = false;
        TimerRestarted?.Invoke();
    }
}
