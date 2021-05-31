using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvade : MonoBehaviour
{
    EnemyBase parent;
    Rigidbody rb;

    Transform target;
    public float timeBetweenChecks;
    float timer;
    public float radius;
    public LayerMask bulletMask;

    public float evadeDistance;
    public float avoidTime;
    float timerAvoid;

    bool avoiding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent = GetComponent<EnemyBase>();
    }

    void Update()
    {
        CheckTarget();

        Avoid();
    }

    private void Avoid()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= evadeDistance)
            {
                timerAvoid = Time.time + avoidTime;

                parent.canMove = false;

                avoiding = true;
            }
        }

        if (avoiding)
        {
            Rigidbody targetRB = target.GetComponent<Rigidbody>();

            Vector3 distanceToTarget = target.transform.position - transform.position;

            float distance = distanceToTarget.magnitude;

            float currentSpeed = rb.velocity.magnitude;

            float prediction = distance / currentSpeed;

            Vector3 explicitTarget = target.transform.position + targetRB.velocity * prediction;

            rb.velocity = (transform.position - explicitTarget).normalized * parent.speed;

            if (Time.time >= timerAvoid)
            {
                parent.canMove = true;

                avoiding = false;
            }
        }
    }

    void CheckTarget()
    {
        if (!avoiding)
        {
            Collider[] possibleTargets = Physics.OverlapSphere(transform.position, radius, bulletMask);

            foreach (Collider item in possibleTargets)
            {
                if (target != null)
                {
                    if (Vector3.Distance(transform.position, item.transform.position) < Vector3.Distance(transform.position, target.position))
                    {
                        target = item.transform;
                    }
                }

                else
                {
                    target = item.transform;
                }
            }

            timer = Time.time + timeBetweenChecks;
        }
    }
}
