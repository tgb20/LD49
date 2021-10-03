using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipSpawner : MonoBehaviour
{

    public GameObject[] ships;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBoat", 5, 1);
    }

    private void SpawnBoat()
    {
        var boat = ships[Random.Range(0, ships.Length)];

        var point = Random.insideUnitCircle.normalized * 60;

        Instantiate(boat, new Vector3(point.x, 0, point.y), Quaternion.identity);
    }
}
