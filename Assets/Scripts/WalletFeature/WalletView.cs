using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _coinsWalletUiPrefab;
    [SerializeField] private CurrencyView _diamondsWalletUiPrefab;
    [SerializeField] private CurrencyView _energyWalletUiPrefab;
    [SerializeField] private GameObject _uiCanvas;

    private WalletInput _wallet;
    private List<CurrencyView> _walletBalance;
    private Object _currentCurrencyGameObject;

    
    private void Awake()
    {
        if (GetComponentInParent<WalletInput>() != null)
        {
            _wallet = GetComponentInParent<WalletInput>();

            _walletBalance = new List<CurrencyView>(); 

            InstantiateCurrencyView(_coinsWalletUiPrefab.gameObject);
            InstantiateCurrencyView(_diamondsWalletUiPrefab.gameObject);
            InstantiateCurrencyView(_energyWalletUiPrefab.gameObject);

            InitializeCurrencyView();

            _wallet.BalanceUpdated += UpdateBalance;
        }
    }

    private void OnDestroy()
    {
        _wallet.BalanceUpdated -= UpdateBalance;
    }

    private void UpdateBalance(int value,CurrencyType currencyType)
    {
        foreach (CurrencyView currencyView in _walletBalance)
        {
            if(currencyView.CurrencyType == currencyType)
                currencyView.UpdateText(value);
        }
    }

    private void InstantiateCurrencyView(GameObject currencyPrefab)
    {
        _currentCurrencyGameObject = Instantiate(currencyPrefab, _uiCanvas.transform);
        _walletBalance.Add(_currentCurrencyGameObject.GetComponent<CurrencyView>());
        
    }

    private void InitializeCurrencyView()
    {
        foreach (CurrencyView currencyView in _walletBalance)
            currencyView.Initialize();
    }
}
