using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _coinsWalletUiPrefab;
    [SerializeField] private CurrencyView _diamondsWalletUiPrefab;
    [SerializeField] private CurrencyView _energyWalletUiPrefab;
    [SerializeField] private GameObject _uiCanvas;

    private Object _currentCurrencyGameObject;
    private CurrencyView _currentCurrency;

    public void Initialize(IReadonlyVariable<int> coins, IReadonlyVariable<int> diamonds, IReadonlyVariable<int> energy)
    {
        InstantiateCurrencyView(_coinsWalletUiPrefab.gameObject,coins);
        InstantiateCurrencyView(_diamondsWalletUiPrefab.gameObject,diamonds);
        InstantiateCurrencyView(_energyWalletUiPrefab.gameObject,energy);
    }

    private void InstantiateCurrencyView(GameObject currencyPrefab, IReadonlyVariable<int> reactiveCurrency)
    {
        _currentCurrencyGameObject = Instantiate(currencyPrefab, _uiCanvas.transform);
        _currentCurrency = _currentCurrencyGameObject.GetComponent<CurrencyView>();
        _currentCurrency.Initialize(reactiveCurrency);
    }
}
