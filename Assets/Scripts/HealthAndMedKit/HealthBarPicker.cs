using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPicker : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
            PickUp(medKit);
    }

    private void PickUp(MedKit medKit)
    {
        Destroy(medKit.gameObject);

        _healthBar.Add(medKit.Value);
    }
}
