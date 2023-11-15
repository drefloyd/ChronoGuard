using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    [SerializeField]
    public float droneSpeed;    // invader and guardian MUST have negaitves 

    void Update()
    {
        // Move the GameObject forward based on its local position
        transform.Translate(Vector3.back * droneSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
