using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 300;
    public int currentRound;
    public int[] killsToIncreaseRound;
    int enemiesKilled;

    CanvasManager cm;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        cm = FindObjectOfType<CanvasManager>();

        UpdateMoneyText();
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

    public void UpdateMoneyText()
    {
        cm.moneyText.text = "Money: " + money;
    }
}
