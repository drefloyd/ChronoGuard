using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject NukePowerup;

    Renderer beaconToFollow;
    public static float speed = 0.15f;
    //[SerializeField]
    //public float droneSpeed;    // invader and guardian MUST have negaitves, we can remove this 

    scoreScript playerScoreScript;

    public NavMeshAgent agent;
    //public Transform target;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
        Vector3 target = ChooseRandomBeacon();
        agent.SetDestination(target);
    }

    Vector3 ChooseRandomBeacon()
    {
        int beaconChooser = Random.Range(0, 4);    // 0, 1, 2, 3

        //test
        //beaconChooser = 3;

        if (beaconChooser == 0)
        {
            beaconToFollow = GameObject.Find("Piedras.005_Cubo.008_Mat_Piedra").GetComponent<Renderer>();//green
             
        }
        else if (beaconChooser == 1)
        {
            beaconToFollow = GameObject.Find("Piedras.007_Cubo.011_Mat_Piedra").GetComponent<Renderer>();//purple
        }
        else if (beaconChooser == 2)
        {
            beaconToFollow = GameObject.Find("Piedras2_Cubo.017_Mat_Piedra").GetComponent<Renderer>();//yellow
        }
        else
        {
            beaconToFollow = GameObject.Find("Tower").GetComponent<Renderer>();//tower
        }

        //return ther 3d position of the target object
        return beaconToFollow.transform.position;
    }

    void Update()
    {
        //if (beaconToFollow == null)
        //{
        //    Vector3 target = ChooseRandomBeacon();
        //    agent.SetDestination(target);
        //}
        //else
        //{
        //    float X, Y, Z;
        //    if (GetComponent<Renderer>().bounds.center.x > beaconToFollow.bounds.center.x)
        //    {
        //        X = transform.position.x - speed;
        //    }
        //    else
        //    {
        //        X = transform.position.x + speed;
        //    }

        //    //if (GetComponent<Renderer>().bounds.center.y > beaconToFollow.bounds.center.y)
        //    //{
        //    //    Y = transform.position.y - speed;
        //    //}
        //    //else
        //    //{
        //    //    Y = transform.position.y + speed;
        //    //}

        //    if (GetComponent<Renderer>().bounds.center.z > beaconToFollow.bounds.center.z)
        //    {
        //        Z = transform.position.z - speed;
        //    }
        //    else
        //    {
        //        Z = transform.position.z + speed;
        //    }

        //    transform.position = new Vector3(X, Y, Z);
        //}
    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, GetComponent<Renderer>().bounds.center, Quaternion.identity);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerScoreScript.increaseScore();
            //chance of spawning a powerUp nuke:
            int num = Random.Range(1, 5);//1,2,3,4,5
            if (num == 1)
            {
                Instantiate(NukePowerup, GetComponent<Renderer>().bounds.center, Quaternion.identity);
            }
            
        }
        Destroy(gameObject);
    }
}
