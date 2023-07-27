using UnityEngine;

public class BulletController : MonoBehaviour
{
    public void MoveBullet(Transform target, float bulletSpeed)
    {
        var direction = (target.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void RotateBullet(Transform target)
    {
        var targetDirection = target.position - transform.position;
        var angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}