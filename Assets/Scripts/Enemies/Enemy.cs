using HP;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Базовый класс для врагов
    /// </summary>
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
            
            _player.GetComponent<Health>().ChangeHealth(FinishLineDamage);
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}