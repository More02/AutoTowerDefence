using System.Globalization;
using Damage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HP
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private Image _healthBarFilling;
        [SerializeField] private TextMeshPro _healthCountText;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Transform _player;

        private Health _health;
        private HealthData _healthData;
        private BulletDamageController _bulletDamageController;

        private void Awake()
        {
            if (!transform.parent.CompareTag($"MainHealthCanvas"))
            {
                _player = transform.parent.parent;
            }
            _health = _player.GetComponent<Health>();
            _health.onHealthChanged += OnHealthChanged;
            _healthBarFilling.color = _gradient.Evaluate(1);
            _healthCountText.color = _gradient.Evaluate(1);
        }

        private void OnDestroy()
        {
            _health.onHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(HealthData healthData)
        {
            _healthData = healthData;
            _healthBarFilling.fillAmount = healthData.CurrentHealthAsPercange;
            _healthBarFilling.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);

            _healthCountText.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
            _healthCountText.text = healthData.CurrentHealth.ToString(CultureInfo.InvariantCulture);
        }
        
    }
}