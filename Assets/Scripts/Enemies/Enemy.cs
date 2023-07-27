using System;
using Damage;
using GameSessionManager;
using HP;
using UnityEngine;

namespace Enemies
{
    public class Enemy: MonoBehaviour
    {
        private float _speed;
        private int _health;

        private int _finishLineDamage = -1;
        [SerializeField] private GameObject _player;

        public void Initialize(float enemySpeed, int enemyHealth)
        {
            _speed = enemySpeed;
            _health = enemyHealth;
        }

        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag($"Finish")) return;
            
            MakeDamage.Instance.DealDamage(_player.GetComponent<Health>(), _finishLineDamage);
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}