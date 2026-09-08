using System;

public class Timer 
{
    public event Action TimerRestarted;

    private ReactiveVariable<float> _maxTime;
    private ReactiveVariable<float> _currentTime;
    private bool _isRunning;

    public IReadonlyVariable<float> MaxTime => _maxTime;
    public IReadonlyVariable<float> CurrentTime => _currentTime;

    public Timer(float maxTime)
    {
        _maxTime = new ReactiveVariable<float>(maxTime);
        _currentTime = new ReactiveVariable<float>(maxTime);
    }

    public void Update()
    {
        if (_isRunning)
            _currentTime.Value -= UnityEngine.Time.deltaTime;
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
        _currentTime.Value = _maxTime.Value;
        _isRunning = false;
        TimerRestarted?.Invoke();
    }
}
