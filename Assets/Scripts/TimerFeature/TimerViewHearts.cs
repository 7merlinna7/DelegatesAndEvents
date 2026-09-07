using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerViewHearts : MonoBehaviour
{
    [SerializeField] GameObject _uiCanvas;
    [SerializeField] Image _heartTimerPrefab;
    [SerializeField] private int _heartXOffset;

    private float _maxTime;
    private Timer _timer;
    private List<Image> _hearts;
    private int _heartsCount = 0;
    private Vector2 _heartPosition = new Vector2(-816,340);

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimerUpdated += UpdateHearts;
        _timer.TimerRestarted += RestartHearts;
        _maxTime = _timer.MaxTime;

        SpawnHearts();
    }

    private void OnDestroy()
    {
        _timer.TimerUpdated -= UpdateHearts;
        _timer.TimerRestarted -= RestartHearts;
    }

    private void UpdateHearts(float time)
    {
        if (_hearts.Count - time > 1f)
        {
            Destroy(_hearts[_hearts.Count-1].gameObject);
            _hearts.RemoveAt(_hearts.Count-1);
        }
    }

    private void RestartHearts()
    {
        foreach (var heart in _hearts)
            Destroy(heart.gameObject);
        _hearts.Clear();
        _heartsCount = 0;
        SpawnHearts();
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
}