using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyFactory: MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyList;
    private GameObject _enemy;

   // public static EnemyFactory Instance { get; private set; }

    // private void Awake()
    // {
    //     Instance = this;
    // }

    public void CreateEnemy(Vector3 spawnPosition, float speed, int health)
    {
        _enemy = _enemyList[Random.Range(0, _enemyList.Count)];
        var enemyObject = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        var enemy = enemyObject.GetComponent<Enemy>();

        enemy.Initialize(speed, health);
    }
}