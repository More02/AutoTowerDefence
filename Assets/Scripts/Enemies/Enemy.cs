using Damage;
using HP;
using UnityEngine;

namespace Enemies
{
    public class Enemy: MonoBehaviour
    {
        private float _speed;

        private const int FinishLineDamage = -1;
        [SerializeField] private GameObject _player;

        public void Initialize(float enemySpeed)
        {
            _speed = enemySpeed;
        }

        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag($"Finish")) return;
            
            MakeDamage.DealDamage(_player.GetComponent<Health>(), FinishLineDamage);
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}