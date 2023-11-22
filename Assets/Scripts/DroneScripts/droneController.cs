using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField]
    public float droneSpeed;    // invader and guardian MUST have negaitves 

    scoreScript playerScoreScript;

    private void Start()
    {
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
    }

    void Update()
    {
        // Move the GameObject forward based on its local position
        transform.Translate(Vector3.back * droneSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion,collision.transform.position,Quaternion.identity);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerScoreScript.increaseScore();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Beacon"))
        {
            // also do explosion !!
            Debug.Log("drone died");
            Destroy(gameObject);
 
        }
    }
}
