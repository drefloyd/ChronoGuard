using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    public Transform greenBeacon;
    public Transform yellowBeacon;
    public Transform purpleBeacon;
    private Transform beaconToFollow;

    public float droneSpeed = 5f;

    void Start()
    {
        int beaconChooser = Random.Range(0, 3);    // 0,1,2

        if (beaconChooser == 0)
        {
            beaconToFollow = greenBeacon;
        }
        else if (beaconChooser == 1)
        {
            beaconToFollow = yellowBeacon;
        }
        else
        {
            beaconToFollow = purpleBeacon;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (beaconToFollow != null)
        {
            // Calculate the direction from the drone to the target.
            Vector3 direction = (beaconToFollow.position - transform.position).normalized;

            // Move the drone towards the target.
            transform.Translate(direction * droneSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("null beacon");
        }
    }
}
