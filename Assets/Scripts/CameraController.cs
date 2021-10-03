using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform boat;
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - boat.position;
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = boat.position + _offset;
        var transformRef = transform;
        newPos.y = transformRef.position.y;
        transformRef.position = newPos;
    }
}
