using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
            Instantiate(_coinPrefab, _spawnPoints[i].position, Quaternion.identity);
    }
}
