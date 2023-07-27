using System;
using System.Collections;
using HP;
using UnityEngine;

namespace Damage
{
    public class BulletDamageController : MonoBehaviour
    {
        [SerializeField] private int _damageValue = -35;

        private void Start()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy")) return;
            
            MakeDamage.DealDamage(collision.gameObject.GetComponent<Health>(), _damageValue);
            Destroy(gameObject);
        }
        
        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(10);
            Destroy(gameObject);
        }
    }
}