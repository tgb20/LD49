using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    public Transform ship;
    public GameObject[] waterTiles;

    private void Start()
    {
        waterTiles = GameObject.FindGameObjectsWithTag("Water");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var waterTile in waterTiles)
        {
            var dist = Vector3.Distance(ship.position, waterTile.transform.position);

            var water = waterTile.GetComponent<WaterController>();

            if (dist < 50)
            {
                if (water.gridSize != 64)
                {
                    water.NewMesh(64);
                }
            }

            if (dist >= 50 && dist < 80)
            {
                if (water.gridSize != 16)
                {
                    water.NewMesh(16);
                }
            }
            
            if (dist >= 80)
            {
                if (water.gridSize != 4)
                {
                    water.NewMesh(4);
                }
            }
        }
    }
}
