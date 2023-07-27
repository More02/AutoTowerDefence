using System.Collections.Generic;
using UnityEngine;

namespace Damage
{
    public class AutoShooter : MonoBehaviour
    {
        [SerializeField] private float _attackRadius = 5f;
        [SerializeField] private float _fireSpeed = 0.1f; 
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
            if (_target is not null || _enemies.Count <= 0) return;
        
            _target = _enemies[0];
            _enemies.RemoveAt(0);
            RotateTowardsEnemy();
            if (!CanFire()) return;
        
            Fire();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_target == null && other.CompareTag($"Enemy"))
            {
                _target = other.transform;
                RotateTowardsEnemy();
                if (!CanFire()) return;
            
                Fire();
            }
            else if (other.CompareTag($"Enemy"))
            {
                _enemies.Add(other.transform);
            }
        }

        private void RotateTowardsEnemy()
        {
            transform.localScale = _target.position.x < transform.position.x ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
        }

        private bool CanFire()
        {
            return Time.time >= _nextFireTime;
        }
    
        private void Fire()
        {
            var bullet =
                Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.SetActive(true);
            var bulletController = bullet?.GetComponent<BulletMoveController>();
        
            //PlayerAnimation.Instance.SetAttackAnimation();
            if (bulletController is not null)
            {
                bulletController.MoveBullet(_target, _bulletSpeed);
                bulletController.RotateBullet(_target);
            }

            ResetFireTimer();
        }

        private void ResetFireTimer()
        {
            _nextFireTime = Time.time + _fireSpeed;
        }
    }
}