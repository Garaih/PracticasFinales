﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public RectTransform parentPivot;
    public GameObject shopPanel;

    public GameObject[] tower;

    public TurretPoint interactPoint;

    public TextMeshProUGUI moneyText;

    void Start()
    {
        shopPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void BuyTower(int value)
    {
        if (interactPoint.tower == null)
        {
            if (GameManager.Instance.money >= tower[value].GetComponent<TowerBehaviour>().cost)
            {
                GameManager.Instance.money -= tower[value].GetComponent<TowerBehaviour>().cost;

                GameManager.Instance.UpdateMoneyText();

                GameObject newTower = Instantiate(tower[value], interactPoint.transform.position, tower[value].transform.rotation);

                interactPoint.tower = newTower.GetComponent<TowerBehaviour>();

                interactPoint.meshR.material = interactPoint.occupiedMat;
            }
        }
    }

    public void SellTower()
    {
        if (interactPoint.tower != null)
        {
            GameManager.Instance.money += interactPoint.tower.cost;

            GameManager.Instance.UpdateMoneyText();

            Destroy(interactPoint.tower.gameObject);

            interactPoint.meshR.material = interactPoint.freeMat;
        }
    }

    public void LevelUp()
    {
        if (interactPoint.tower != null)
        {
            if (!interactPoint.tower.maxLevel)
            {
                if (GameManager.Instance.money >= interactPoint.tower.cost)
                {
                    GameManager.Instance.money -= interactPoint.tower.cost;

                    GameManager.Instance.UpdateMoneyText();

                    interactPoint.tower.LevelUp();
                }
            }
        }
    }

    public void ClosePanel()
    {
        shopPanel.SetActive(false);
    }
}
