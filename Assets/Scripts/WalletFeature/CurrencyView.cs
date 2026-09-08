using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private TMP_Text _currencyViewText;
    [SerializeField] private Vector2 _currencyViewOffset;

    private Image _currencyViewImage;
    private IReadonlyVariable<int> _reactiveCurrency;


    private void Awake() => _currencyViewImage = GetComponent<Image>();

    public void Initialize(IReadonlyVariable<int> reactiveCurrency)
    {
        _currencyViewImage.rectTransform.anchoredPosition = _currencyViewOffset;
        _reactiveCurrency = reactiveCurrency;
        _reactiveCurrency.Changed += UpdateText;
    }

    private void OnDestroy() => _reactiveCurrency.Changed -= UpdateText;

    private void UpdateText(int oldValue, int value) => _currencyViewText.text = value.ToString();
}
