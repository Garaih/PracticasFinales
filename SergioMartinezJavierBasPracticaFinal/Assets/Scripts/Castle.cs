using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float maxHP;
    float currentHP;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.TryGetComponent(out EnemyBase enemy))
            {
                TakeDamage(enemy.damage);
            }
        }
    }

    public void TakeDamage(float value)
    {
        currentHP -= value;

        if (currentHP <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
