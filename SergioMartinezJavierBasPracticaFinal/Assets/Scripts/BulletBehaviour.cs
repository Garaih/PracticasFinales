using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject targetEnemy;
    protected Rigidbody rb_Comp;
    protected Rigidbody target;
    public float Speed;
    public float damage;
    public LayerMask enemyLayer;

    protected virtual void Start()
    {
        rb_Comp = GetComponent<Rigidbody>();

        rb_Comp.velocity = transform.forward * Speed;

        ChooseTarget();
    }

    protected virtual void Update()
    {
        Vector3 distanceToTarget = target.position - transform.position;

        float distance = distanceToTarget.magnitude;

        float speed = rb_Comp.velocity.magnitude;

        float prediction = distance / speed;

        Vector3 explicitTarget = target.position + target.velocity * prediction;

        rb_Comp.velocity = (explicitTarget - transform.position).normalized * Speed;

        transform.rotation = Quaternion.LookRotation(explicitTarget - transform.position);

    }

    void ChooseTarget()
    {
        target = targetEnemy.GetComponent<Rigidbody>();
    }
}
