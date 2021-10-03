using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            StateManager.Instance.GameLost();
        }
    }
}
