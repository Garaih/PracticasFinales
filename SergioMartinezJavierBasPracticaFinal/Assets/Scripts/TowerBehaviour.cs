using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject bullet;
    GameObject newBullet;
    public GameObject firePoint;
    public float damage;
    public float bulletSpeed;

    public int radius;
    public int cost;
    public int level;
    bool maxLevel = false;

    public float cadence;
    float shootTimer;

    public LayerMask enemyLayer;
    float distanceEnemyAux;
    GameObject enemyTarget;

    public GameObject EnemyTarget { get => enemyTarget; set => enemyTarget = value; }

    void Start()
    {
        level = 1;   
    }

    void Update()
    {
        LockTarget();

        if(Time.time > shootTimer && enemyTarget != null)
        {
            Shoot();
        }
    }

    void LockTarget()
    {
        distanceEnemyAux = radius;
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach(Collider enemy in enemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) < distanceEnemyAux)
            {
                enemyTarget = enemy.gameObject;
                distanceEnemyAux = Vector3.Distance(transform.position, enemy.transform.position);
            }
        }
    }

    void Shoot()
    {
        shootTimer += Time.time;
        newBullet = Instantiate(bullet, firePoint.transform.position, bullet.transform.rotation);

        if(newBullet.TryGetComponent(out BulletBehaviour bulletComp))
        {
            bulletComp.damage = damage;
            bulletComp.targetEnemy = enemyTarget;
            bulletComp.Speed = bulletSpeed;
        }
    }

    public void LevelUp()
    {
        if(level < 5)
        {
            level++;
            cadence -= .5f;
            cost += 100;
            radius += 10;
            damage += 50;
        }

        else
        {
            maxLevel = true;
        }
        
    }
}
