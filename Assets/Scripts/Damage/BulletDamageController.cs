using HP;
using UnityEngine;

namespace Damage
{
    public class BulletDamageController : MonoBehaviour
    {
        [SerializeField] private int _damageValue = -35;
        private Collider2D _target;

        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy")) return;
            
            _target = collision;
            MakeDamage.Instance.DealDamage(collision.gameObject.GetComponent<Health>(), _damageValue);
            Destroy(gameObject);
        }
    }
}