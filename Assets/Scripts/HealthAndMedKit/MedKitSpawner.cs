using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _gameObject;

    private float _appearancetime = float.MaxValue;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), _appearancetime);
    }

    private void Spawn()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        Instantiate(_gameObject, _spawnPoints[index]);
        Invoke(nameof(Spawn), _appearancetime);
    }
}
