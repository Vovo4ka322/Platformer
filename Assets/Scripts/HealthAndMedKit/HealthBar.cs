using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int _maxValue = 100;

    public event Action<int> Changed;

    [field: SerializeField] public int Value { get; private set; }

    public void Add(int amount)
    {
        if (Value != _maxValue)
        {
            Value += amount;
            Changed?.Invoke(Value);
        }
        else
        {
            Value = _maxValue;
        }
    }
}
