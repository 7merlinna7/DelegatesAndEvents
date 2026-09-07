using UnityEngine;

public class WalletInput : MonoBehaviour
{
    [SerializeField] private int _currencyCount;
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
        _walletView.Initialize(_wallet);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.AddCurrency(_currencyCount, CurrencyType.Coins);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.RemoveCurrency(_currencyCount, CurrencyType.Coins);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.AddCurrency(_currencyCount, CurrencyType.Diamonds);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            _wallet.RemoveCurrency(_currencyCount, CurrencyType.Diamonds);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            _wallet.AddCurrency(_currencyCount, CurrencyType.Energy);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _wallet.RemoveCurrency(_currencyCount, CurrencyType.Energy);
    }
}

