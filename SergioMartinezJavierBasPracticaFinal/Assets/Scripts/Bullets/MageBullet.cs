using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBullet : BulletBehaviour
{
    public float explosionRadius;

    private void OnTriggerEnter()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            enemy.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
