using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    void Start()
    {
        Destroy(gameObject, 3);//only lasts 3 seconds
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //kill all drones
            GameObject[] allDrones = GameObject.FindGameObjectsWithTag("Drone");

            foreach (GameObject drone in allDrones)
            {
                Destroy(drone);
                //maybe add the score for each or that might be too much
            }
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
