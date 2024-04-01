using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _value;

    public event Action<int> Changed;

    public void Add(int amount)
    {
        _value += amount;
        Changed?.Invoke(_value);
    }
}
