using HP;
using UnityEngine;

namespace Damage
{
    public class MakeDamage: MonoBehaviour
    {
        public static MakeDamage Instance { get; private set; }

        private void Start()
        {
            Instance = this;
        }

        public void DealDamage(Health health, int damageValue)
        {
            if (health is null) return;

            health.ChangeHealth(damageValue);
        }
    }
}