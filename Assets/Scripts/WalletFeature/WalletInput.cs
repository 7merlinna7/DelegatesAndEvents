using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletInput : MonoBehaviour
{
    [SerializeField] private int _currencyCount;

    private Wallet _wallet;

    public event Action<int, CurrencyType> BalanceUpdated
    {
        add => _wallet.BalanceUpdated += value;
        remove => _wallet.BalanceUpdated -= value;
    }

    private void Awake()
    {
        _wallet = new Wallet();
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

