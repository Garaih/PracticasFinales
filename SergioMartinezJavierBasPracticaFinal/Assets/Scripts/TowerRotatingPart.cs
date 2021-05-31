using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotatingPart : MonoBehaviour
{
    TowerBehaviour parent;
    void Start()
    {
        parent = GetComponentInParent<TowerBehaviour>();
    }


    void Update()
    {
        if(parent.EnemyTarget != null)
        {
            transform.rotation = Quaternion.LookRotation(parent.EnemyTarget.transform.position - transform.position);
        }
    }
}
