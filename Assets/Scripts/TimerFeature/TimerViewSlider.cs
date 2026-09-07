using UnityEngine;
using UnityEngine.UI;

public class TimerViewSlider : MonoBehaviour
{
    [SerializeField] Slider _timerSliderPrefab;
    [SerializeField] GameObject _uiCanvas;

    private Slider _timerSlider;
    private float _maxTime;
    private GameObject _timerView;
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimerUpdated += UpdateSlider;
        _maxTime = _timer.MaxTime;

        SpawnSlider();
        UpdateSlider(_maxTime);
    }

    private void UpdateSlider(float time) => _timerSlider.value = time / _maxTime;

    private void SpawnSlider()
    {
        _timerView = Instantiate(_timerSliderPrefab.gameObject, _uiCanvas.transform);
        _timerSlider = _timerView.GetComponent<Slider>();
    }
}
