using UnityEngine;

public class Enemy: MonoBehaviour
{
    private float _speed;
    private int _health;

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
        if (collision.CompareTag($"Finish"))
        {
            //GameManager.Instance.DecreasePlayerHealth(1);
            Destroy(gameObject);
        }
    }

    private void DecreaseHealth(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}