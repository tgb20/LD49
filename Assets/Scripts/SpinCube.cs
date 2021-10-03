using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinCube : MonoBehaviour
{

    private float _speed;
    
    // Update is called once per frame

    private void Start()
    {
        _speed = Random.Range(0, 40f);
    }

    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
