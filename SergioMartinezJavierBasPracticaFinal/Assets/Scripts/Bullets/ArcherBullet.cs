using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBullet : BulletBehaviour
{
    public int explosionRadius;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }

        Destroy(this);
    }
}
