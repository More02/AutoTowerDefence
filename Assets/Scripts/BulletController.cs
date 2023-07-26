using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static BulletController Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void MoveBullet(Transform target, float bulletSpeed)
    {
        var direction = (target.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}