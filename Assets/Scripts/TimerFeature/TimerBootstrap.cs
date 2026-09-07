using UnityEngine;

public class TimerBootstrap : MonoBehaviour
{
    [SerializeField] private float _maxtime;
    [SerializeField] private TimerViewSlider _slider;
    [SerializeField] private TimerViewHearts _hearts;
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(_maxtime);

        _hearts.Initialize(_timer);
        _slider.Initialize(_timer);
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
