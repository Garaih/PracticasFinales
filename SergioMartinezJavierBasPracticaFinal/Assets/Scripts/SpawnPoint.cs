using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public Transform[] pathPoints;

    public float spawnDelay;
    float timer;

    void Start()
    {
        timer = Time.time + spawnDelay + Random.Range(-spawnDelay * 2, spawnDelay * 2) * .1f;
    }

    void Update()
    {
        if (Time.time >= timer)
        {
            if (GameManager.Instance.currentRound < 1)
            {
                GameObject newEnemy = Instantiate(enemiesToSpawn[0], transform.position, enemiesToSpawn[0].transform.rotation);

                if (newEnemy.TryGetComponent(out EnemyBase enemy))
                {
                    enemy.SetPath(pathPoints);
                }
            }

            else if (GameManager.Instance.currentRound < 2)
            {
                int value = Random.Range(0, enemiesToSpawn.Length - 1);

                GameObject newEnemy = Instantiate(enemiesToSpawn[value], transform.position, enemiesToSpawn[value].transform.rotation);

                if (newEnemy.TryGetComponent(out EnemyBase enemy))
                {
                    enemy.SetPath(pathPoints);
                }
            }

            else if (GameManager.Instance.currentRound < 3)
            {
                int value = Random.Range(0, enemiesToSpawn.Length - 1);

                GameObject newEnemy = Instantiate(enemiesToSpawn[value], transform.position, enemiesToSpawn[value].transform.rotation);

                if (newEnemy.TryGetComponent(out EnemyBase enemy))
                {
                    enemy.SetPath(pathPoints);
                }
            }

            else if (GameManager.Instance.currentRound < 4)
            {
                int value = Random.Range(0, enemiesToSpawn.Length);

                GameObject newEnemy = Instantiate(enemiesToSpawn[value], transform.position, enemiesToSpawn[value].transform.rotation);

                if (newEnemy.TryGetComponent(out EnemyBase enemy))
                {
                    enemy.SetPath(pathPoints);
                }
            }

            timer = Time.time + spawnDelay - GameManager.Instance.currentRound / 2;
        }
    }
}
