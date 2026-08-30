using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private TMP_Text _currencyViewText;
    [SerializeField] private Vector2 _currencyViewOffset;
    private Image _currencyViewImage;

    public CurrencyType CurrencyType=> _currencyType;

    private void Awake()
    {
        _currencyViewImage = GetComponent<Image>();
    }

    public void Initialize()
    {
        _currencyViewImage.rectTransform.anchoredPosition = _currencyViewOffset;
    }

    public void UpdateText(int value)
    {
        _currencyViewText.text = value.ToString();
    }
}
