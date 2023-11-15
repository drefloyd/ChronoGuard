using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    public float droneSpeed = 10f;

    void Update()
    {
        // Move the GameObject forward based on its local position
        transform.Translate(Vector3.forward * droneSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
