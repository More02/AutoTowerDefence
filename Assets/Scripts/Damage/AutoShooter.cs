using System.Collections.Generic;
using UnityEngine;

namespace Damage
{
    /// <summary>
    /// Логика автоматического шутера
    /// </summary>
    public class AutoShooter : MonoBehaviour
    {
        [SerializeField] private float _attackRadius = 5f;
        [SerializeField] private float _fireSpeed = 0.5f;
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private GameObject _bullet;
        private readonly List<Transform> _enemies = new();

        private float _nextFireTime;
        private Transform _target;

        private void Start()
        {
            gameObject.GetComponent<CircleCollider2D>().radius = _attackRadius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag($"Enemy")) return;
            
            if (!_enemies.Contains(other.transform))
                _enemies.Add(other.transform);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_enemies.Count <= 0) return;
            
            _target = _enemies[0];
            RotateTowardsEnemy();
                
            if (!CanFire()) return;
            Fire();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag($"Enemy")) return;
            
            if (_enemies.Contains(other.transform))
                _enemies.Remove(other.transform);
        }

        private void RotateTowardsEnemy()
        {
            transform.localScale = _target.transform.position.x < transform.position.x
                ? new Vector3(-1f, 1f, 1f)
                : new Vector3(1f, 1f, 1f);
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
            var bulletController = bullet.GetComponent<BulletMoveController>();

            //PlayerAnimation.Instance.SetAttackAnimation();

            bulletController.MoveBullet(_target.transform, _bulletSpeed);
            bulletController.RotateBullet(_target.transform);

            ResetFireTimer();
        }

        private void ResetFireTimer()
        {
            _nextFireTime = Time.time + _fireSpeed;
        }
    }
}