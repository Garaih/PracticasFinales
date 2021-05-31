using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money;
    public int currentRound;
    public int[] killsToIncreaseRound;
    int enemiesKilled;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CheckRound()
    {
        enemiesKilled++;

        if (enemiesKilled >= killsToIncreaseRound[currentRound])
        {
            enemiesKilled = 0;
            currentRound++;
        }
    }
}
