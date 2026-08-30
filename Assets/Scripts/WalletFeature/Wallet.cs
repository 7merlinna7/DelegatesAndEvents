using System;
using System.Collections.Generic;

public class Wallet
{
    public event Action<int,CurrencyType> BalanceUpdated;

    private Dictionary<CurrencyType, int> _wallet = new Dictionary<CurrencyType, int>() 
    {
        { CurrencyType.Coins, 0 },
        { CurrencyType.Diamonds, 0 },
        { CurrencyType.Energy, 0 },
    };

    public void AddCurrency(int value, CurrencyType currencyType)
    {
        _wallet[currencyType] += value;
        BalanceUpdated?.Invoke(_wallet[currencyType], currencyType);
    }

    public void RemoveCurrency(int value, CurrencyType currencyType)
    {
        _wallet[currencyType] -= value;

        if (_wallet[currencyType] < 0)
            _wallet[currencyType] = 0;

        BalanceUpdated?.Invoke(_wallet[currencyType], currencyType);
    }
}
