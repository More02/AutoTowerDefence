using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyFactory: MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyList;
        private GameObject _enemy;

        public void CreateEnemy(Vector3 spawnPosition, float speed)
        {
            _enemy = _enemyList[Random.Range(0, _enemyList.Count)];
            var enemyObject = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemyObject.SetActive(true);
            var enemy = enemyObject.GetComponent<Enemy>();

            enemy.Initialize(speed);
        }
    }
}