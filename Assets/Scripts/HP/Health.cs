using System;
using UnityEngine;

namespace HP
{
    public class Health: MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public event Action<HealthData> onHealthChanged;

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
                Death();
            }
            else
            {
                InvokeHealthChanged();
            }
        }

        private void Death()
        {
            onHealthChanged?.Invoke(new HealthData(0, 0));
            Destroy(gameObject);
        }

        private void InvokeHealthChanged()
        {
            var currentHealthAsPercange = (float)_currentHealth / _maxHealth;
            onHealthChanged?.Invoke(new HealthData(currentHealthAsPercange, _currentHealth));
        }
    }
}