using TMPro;
using UnityEngine;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    private EnemyDestroyer _enemyDestroyer;

    private void Awake()
    {
        _enemyDestroyer = GetComponentInParent<EnemyDestroyer>();
        _enemyDestroyer.EnemiesUpdated += UpdateText;
    }

    private void OnDestroy() => _enemyDestroyer.EnemiesUpdated -= UpdateText;

    private void UpdateText(int value) => _counterText.text = value.ToString();
}
