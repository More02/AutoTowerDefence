using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [SerializeField] private float _attackRadius = 5f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private GameObject _bullet;
    private readonly List<Transform> _enemies = new();

    private float _nextFireTime;
    private Transform _target;

    private void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = _attackRadius;
    }

    private void Update()
    {
        if (_target is null && _enemies.Count > 0)
        {
            _target = _enemies[0];
            _enemies.RemoveAt(0);
            RotateTowardsEnemy();
        }


        if (!CanFire()) return;
        
        Fire();
        ResetFireTimer();
        Debug.Log(_target.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_target == null && other.CompareTag($"Enemy"))
        {
            _target = other.transform;
            RotateTowardsEnemy();
        }
        else if (other.CompareTag($"Enemy"))
        {
            _enemies.Add(other.transform);
        }
    }

    private void RotateTowardsEnemy()
    {
        var direction = (_target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector2(direction.x, 0f));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }
    
    private void Fire()
    {
        var bullet =
            Instantiate(_bullet, transform.position, Quaternion.identity);
        var bulletController = bullet?.GetComponent<BulletController>();

        if (bulletController is not null)
        {
            BulletController.Instance.MoveBullet(_target, _bulletSpeed);
        }

        _nextFireTime = Time.time + _fireRate;
    }

    private void ResetFireTimer()
    {
        _nextFireTime = Time.time + _fireRate;
    }
}