using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIBoat : MonoBehaviour
{

    public float speed = 100f;

    private Rigidbody _rigidbody;
    private Transform _boat;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boat = GameObject.FindGameObjectWithTag("Boat").transform;
        transform.Rotate(Vector3.up, Random.Range(0f, 360f));   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        if (Vector3.Distance(_boat.position, transform.position) > 100)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
