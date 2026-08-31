using System;

public class Timer 
{
    public event Action<float> TimerUpdated;
    public event Action TimerRestarted;

    private float _maxTime;
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

    public Timer(float maxTime)
    {
        _maxTime = maxTime;
        _currentTime = maxTime;
    }

    public void Update()
    {
        if (_isRunning)
            CurrentTime -= UnityEngine.Time.deltaTime;
    }

    public void StartTimer()
    {
        if (_isRunning == false)
            _isRunning = true;
    }

    public void StopTimer()
    {
        if (_isRunning)
            _isRunning = false;
    }

    public void RestartTimer()
    {
        CurrentTime = _maxTime;
        _isRunning = false;
        TimerRestarted?.Invoke();
    }
}
