using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Логика спавна врагов
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnTimeoutRangeMin = 0.5f;
        [SerializeField] private float _spawnTimeoutRangeMax = 1.5f;
        [SerializeField] private float _enemySpeedRangeMin = 1f;
        [SerializeField] private float _enemySpeedRangeMax = 2f;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private WaitForSeconds _spawnTimeout;
        private const bool IsSpawning = true;

        private void Start()
        {
            _spawnTimeout = new WaitForSeconds(Random.Range(_spawnTimeoutRangeMin, _spawnTimeoutRangeMax));
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (IsSpawning)
            {
                var randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
                var enemySpeed = Random.Range(_enemySpeedRangeMin, _enemySpeedRangeMax);

                _enemyFactory.CreateEnemy(randomSpawnPoint.position, enemySpeed);

                yield return _spawnTimeout;
            }
        }
    }
}