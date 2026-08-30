using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] GameObject _uiCanvas;
    [SerializeField] Slider _timerViewUiPrefab;
    [SerializeField] Image _heartTimerPrefab;
    [SerializeField] private int _heartXOffset;

    private GameObject _timerView;
    private Slider _timerSlider;
    private Timer _timer;
    private int _maxTime;
    private List<Image> _hearts;
    private int _heartsCount = 0;
    private Vector2 _heartPosition = new Vector2(-816,340);

    private void Awake()
    {
        if (GetComponentInParent<Timer>() != null)
        {

            _timer = GetComponentInParent<Timer>();
            _maxTime = (int)_timer.MaxTime;

            SpawnSlider();

            SpawnHearts();

            _timer.TimerUpdated += UpdateSlider;
            _timer.TimerUpdated += UpdateHearts;
            _timer.TimerRestarted += Restarthearts;
        }
    }

    private void OnDestroy()
    {
        _timer.TimerUpdated -= UpdateSlider;
        _timer.TimerUpdated -= UpdateHearts;
        _timer.TimerRestarted -= Restarthearts;
    }

    private void UpdateSlider(float time)
    {
        _timerSlider.value = time/_maxTime;
    }

    private void UpdateHearts(float time)
    {
        if (_hearts.Count - time > 1f)
        {
            Destroy(_hearts[_hearts.Count-1].gameObject);
            _hearts.RemoveAt(_hearts.Count-1);
        }
    }

    private void SpawnSlider()
    {
        _timerView = Instantiate(_timerViewUiPrefab.gameObject, _uiCanvas.transform);
        _timerSlider = _timerView.GetComponent<Slider>();
    }

    private void SpawnHearts()
    {
        _hearts = new List<Image>();
        while (_heartsCount < _maxTime)
        {
            _hearts.Add(Instantiate(_heartTimerPrefab, _uiCanvas.transform));
            _hearts[_heartsCount].rectTransform.anchoredPosition = new Vector2(_heartPosition.x + _heartsCount * _heartXOffset, _heartPosition.y);
            _heartsCount++;
        }
    }

    private void Restarthearts()
    {
        foreach (var heart in _hearts) 
            Destroy(heart.gameObject);
        _hearts.Clear();
        _heartsCount = 0;
        SpawnHearts();
    }
}
