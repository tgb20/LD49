using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floatCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    
    private void FixedUpdate()
    {
        var pos = transform.position;
        
        rigidbody.AddForceAtPosition(Physics.gravity / floatCount, pos, ForceMode.Acceleration);
        
        var waveHeight = Waver.Instance.GetWaveHeight(pos.x, pos.z);
        if (!(transform.position.y < waveHeight)) return;
        var displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
        rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), pos, ForceMode.Acceleration);
        rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
