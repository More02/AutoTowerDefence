using HP;

namespace Damage
{
    public static class MakeDamage
    {
        public static void DealDamage(Health health, int damageValue)
        {
            if (health is null) return;

            health.ChangeHealth(damageValue);
        }
    }
}