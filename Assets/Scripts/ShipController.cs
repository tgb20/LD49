using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    Rigidbody rigidbody;
    public float torque = 3f;
    public float speed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var turn = Input.GetAxis("Horizontal");
        rigidbody.AddTorque(transform.up * torque * turn);
        var power = Input.GetAxis("Vertical");
        rigidbody.AddForce(transform.forward * speed * power);


        StateManager.Instance.distance = (int) Vector3.Distance(transform.position, new Vector3(-5, 0, 320));

    }
}
