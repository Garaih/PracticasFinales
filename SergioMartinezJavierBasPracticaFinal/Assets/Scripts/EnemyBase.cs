﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Transform[] pathPoints;
    int currentPoint;

    Rigidbody rb;

    public float speed;
    public float acceleration;
    public float turnDistance;
    public float damage;
    public float maxHP;
    float currentHP;

    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentHP = maxHP;
    }

    void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, pathPoints[currentPoint].position) > turnDistance)
            {
                Vector3 desiredSpeed = (pathPoints[currentPoint].position - transform.position).normalized * speed;

                rb.velocity = Vector3.MoveTowards(rb.velocity, desiredSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentPoint++;

                if (currentPoint >= pathPoints.Length)
                {
                    currentPoint = 0;
                }
            }
        }
    }

    public void SetPath(Transform[] array) 
    {
        pathPoints = array;

        canMove = true;
    }

    public void TakeDamage(float value)
    {
        currentHP -= value;

        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
