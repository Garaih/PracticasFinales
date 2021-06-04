using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPoint : MonoBehaviour
{
    public Material freeMat, selectedMat, occupiedMat;
    public MeshRenderer meshR;

    public TowerBehaviour tower;

    public bool interacting;

    CanvasManager cm;

    void Start()
    {
        if (tower == null)
            meshR.material = freeMat;

        cm = FindObjectOfType<CanvasManager>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        TurretPoint[] points = FindObjectsOfType<TurretPoint>();

        foreach (TurretPoint item in points)
        {
            item.interacting = false;

            if (item.tower != null)
            {
                item.meshR.material = item.occupiedMat;
            }

            else
            {
                item.meshR.material = item.freeMat;
            }
        }

        meshR.material = selectedMat;

        interacting = true;

        cm.interactPoint = this;

        cm.parentPivot.localPosition = transform.position;

        cm.shopPanel.SetActive(true);

        if (tower != null)
        {
            cm.levelUpText.text = "Level Up: " + tower.cost;
        }

        else
        {
            cm.levelUpText.text = "Level Up: ???";
        }
    }
}
