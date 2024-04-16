using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _gameObject;

    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        Instantiate(_gameObject, _spawnPoints[index]);
    }
}
