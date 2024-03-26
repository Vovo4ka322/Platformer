using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMash;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.Changed += OnChanged;
    }

    private void OnChanged(int value)
    {
        _textMash.text = value.ToString();
    }
}
