using System;
using System.Collections;
using UnityEngine;

public class ArrivalChecker : MonoBehaviour
{
    public bool hasShipArrived = false;
    private BoxCollider _grabber;
    public int cargoArrived = 0;

    private void Start()
    {
        _grabber = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            if (!hasShipArrived)
            {
                hasShipArrived = true;
                _grabber.center = new Vector3(0f, 0f, -1f);
                _grabber.size = new Vector3(1f, 1f, 3.2f);
                StartCoroutine(ScoreChecker());
            }
            cargoArrived++;
            Destroy(other.gameObject);
        }
    }

    IEnumerator ScoreChecker()
    {
        yield return new WaitForSeconds(0.5f);
        StateManager.Instance.GameWon(cargoArrived);
    }
}
