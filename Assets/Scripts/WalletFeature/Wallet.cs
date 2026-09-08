using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<int>> _wallet = new Dictionary<CurrencyType, ReactiveVariable<int>>
    {
        { CurrencyType.Coins, new ReactiveVariable<int>(0) },
        { CurrencyType.Diamonds, new ReactiveVariable<int>(0) },
        { CurrencyType.Energy, new ReactiveVariable<int>(0) },
    };

    public IReadonlyVariable<int> Coins => _wallet[CurrencyType.Coins];
    public IReadonlyVariable<int> Diamonds => _wallet[CurrencyType.Diamonds];
    public IReadonlyVariable<int> Energy => _wallet[CurrencyType.Energy];

    public void AddCurrency(int value, CurrencyType currencyType) => _wallet[currencyType].Value += value;

    public void RemoveCurrency(int value, CurrencyType currencyType)
    {
        _wallet[currencyType].Value -= value;

        if (_wallet[currencyType].Value < 0)
            _wallet[currencyType].Value = 0;
    }
}
