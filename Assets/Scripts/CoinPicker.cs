using System;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            PickUp(coin);
    }

    private void PickUp(Coin coin)
    {
        Destroy(coin.gameObject);

        _wallet.Add(coin.Value);
    }
}
