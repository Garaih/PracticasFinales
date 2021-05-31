using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBullet : BulletBehaviour
{
    public int explosionRadius;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
