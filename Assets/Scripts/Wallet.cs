using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int> Changed;

    private int _value;

    public void Add(int amount)
    {
        _value += amount;
        Changed?.Invoke(_value);
    }
}
