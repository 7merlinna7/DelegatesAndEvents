using UnityEngine;
using UnityEngine.UI;

public class TimerViewSlider : MonoBehaviour
{
    [SerializeField] Slider _timerSliderPrefab;
    [SerializeField] GameObject _uiCanvas;

    private Slider _timerSlider;
    private IReadonlyVariable<float> _currentTime;
    private IReadonlyVariable<float> _maxTime;

    private GameObject _timerView;
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _maxTime = _timer.MaxTime;

        _timer.CurrentTime.Changed += UpdateSlider;

        SpawnSlider();
    }

    private void UpdateSlider(float oldTime,float currentTime) => _timerSlider.value = currentTime / _maxTime.Value;

    private void SpawnSlider()
    {
        _timerView = Instantiate(_timerSliderPrefab.gameObject, _uiCanvas.transform);
        _timerSlider = _timerView.GetComponent<Slider>();
    }
}
