using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float maxHP;
    float currentHP;

    void Start()
    {
        currentHP = maxHP;
        print(currentHP);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBase>() != null)
        {
            if (other.TryGetComponent(out EnemyBase enemy))
            {
                TakeDamage(enemy.damage);

                Destroy(other.gameObject);
            }
        }
    }

    public void TakeDamage(float value)
    {
        currentHP -= value;

        print(currentHP);

        if (currentHP <= 0)
        {
            Time.timeScale = 0;
            print("GG nice tutorial");
        }
    }
}
