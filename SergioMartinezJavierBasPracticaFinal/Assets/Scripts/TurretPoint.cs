using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPoint : MonoBehaviour
{
    public Material freeMat, selectedMat, occupiedMat;
    public MeshRenderer meshR;

    TowerBehaviour tower;

    void Start()
    {
        if (tower == null)
            meshR.material = freeMat;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
}
