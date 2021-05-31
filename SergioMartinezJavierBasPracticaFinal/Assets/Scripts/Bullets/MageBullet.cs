using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBullet : BulletBehaviour
{
    public int explosionRadius;

    private void OnTriggerEnter()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        //OnDrawGizmosSelected();
        foreach (Collider enemy in enemies)
        {
            enemy.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }

    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }*/
}
