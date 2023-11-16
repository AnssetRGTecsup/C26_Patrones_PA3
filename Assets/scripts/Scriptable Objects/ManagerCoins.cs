using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Coin Manager", menuName = "ScriptableObjects/Coin Manager", order =0)]
public class ManagerCoins : ScriptableObject
{
    [SerializeField] private int _currentCoins;

    public int CurrentCoints => _currentCoins;

    public event Action<int> OnCurrencyChange;

    public void SetUp()
    {
        _currentCoins = 0;
    }

    public bool PayCoins(int amount)
    {
        if (_currentCoins < amount) return false;

        _currentCoins -= amount;

        return true;
    }

    public void AddCoins(int amount)
    {
        _currentCoins += amount;

        OnCurrencyChange?.Invoke(_currentCoins);
    }

    public void Invest()
    {
        if (_currentCoins <= 0)
        {
            return;
        }

        int n = UnityEngine.Random.Range(0, 101);
        Debug.Log(n);

        //_currentCoins += (n < 30 ? +1 : -1) * (_currentCoins / 2);

        if (n < 30)
        {
            _currentCoins += (_currentCoins / 2);
        }
        else
        {
            _currentCoins -= (_currentCoins / 2);
        }

        OnCurrencyChange?.Invoke(_currentCoins);
    }
}
