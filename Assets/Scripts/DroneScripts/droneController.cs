using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;

    Renderer beaconToFollow;
    public static float speed =0.1f;
    [SerializeField]
    public float droneSpeed;    // invader and guardian MUST have negaitves, we can remove this 

    scoreScript playerScoreScript;

    private void Start()
    {
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
        ChooseRandomBeacon();
    }

    void ChooseRandomBeacon()
    {
        int beaconChooser = Random.Range(0, 3);    // 0, 1, 2
        if (beaconChooser == 0)
        {
            beaconToFollow = GameObject.Find("Piedras.005_Cubo.008_Mat_Piedra").GetComponent<Renderer>();//green
        }
        else if (beaconChooser == 1)
        {
            beaconToFollow = GameObject.Find("Piedras.007_Cubo.011_Mat_Piedra").GetComponent<Renderer>();//purple
        }
        else
        {
            beaconToFollow = GameObject.Find("Piedras2_Cubo.017_Mat_Piedra").GetComponent<Renderer>();//yellow
        }
    }

    void Update()
    {
        if (beaconToFollow == null)
        {
            ChooseRandomBeacon();
        }
        else
        {
            float X, Y, Z;
            if (GetComponent<Renderer>().bounds.center.x > beaconToFollow.bounds.center.x)
            {
                X = transform.position.x - speed;
            }
            else
            {
                X = transform.position.x + speed;
            }

            if (GetComponent<Renderer>().bounds.center.y > beaconToFollow.bounds.center.y)
            {
                Y = transform.position.y - speed;
            }
            else
            {
                Y = transform.position.y + speed;
            }

            if (GetComponent<Renderer>().bounds.center.z > beaconToFollow.bounds.center.z)
            {
                Z = transform.position.z - speed;
            }
            else
            {
                Z = transform.position.z + speed;
            }

            transform.position = new Vector3(X, Y, Z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, GetComponent<Renderer>().bounds.center, Quaternion.identity);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerScoreScript.increaseScore();
            
        }
        else if (collision.gameObject.CompareTag("Beacon"))
        {
            // also do explosion !!
            Debug.Log("drone died");
         
        }
        Destroy(gameObject);
    }
}
