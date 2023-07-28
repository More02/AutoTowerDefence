using System;
using System.Collections;
using GameSessionManager;
using Movement;
using UnityEngine;

namespace HP
{
    /// <summary>
    /// Базовый класс здоровья
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public event Action<HealthData> OnHealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void ChangeHealth(int value)
        {
            _currentHealth += value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                if (gameObject.CompareTag("Enemy"))
                {
                    GameManager.Instance.CountOfDestroyedEnemy++;
                    GameManager.Instance.CheckWin();
                }

                StartCoroutine(Death());
            }
            else
            {
                InvokeHealthChanged();
            }
        }

        private IEnumerator Death()
        {
            OnHealthChanged?.Invoke(new HealthData(0, 0));
            if (gameObject.CompareTag("Player"))
            {
                PlayerAnimation.Instance.SetDeathAnimation();
                transform.localScale = Vector3.one;
                yield return new WaitForSeconds(0.5f);
                GameManager.Instance.Loose();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InvokeHealthChanged()
        {
            var currentHealthAsPercange = (float)_currentHealth / _maxHealth;
            OnHealthChanged?.Invoke(new HealthData(currentHealthAsPercange, _currentHealth));
        }
    }
}