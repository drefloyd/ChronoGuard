using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject NukePowerup;

    Renderer beaconToFollow;
    public static float speed = 0.15f;
    //[SerializeField]
    //public float droneSpeed;    // invader and guardian MUST have negaitves, we can remove this 

    scoreScript playerScoreScript;

    public Vector3 target;
    AudioManager audioManager;

    private void Start()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
        ChooseRandomBeacon();


    }

    void ChooseRandomBeacon()
    {
        int beaconChooser = Random.Range(0, 6);    // 0, 1, 2, 3, 4, 5

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
        else if (beaconChooser == 3)
        {
            beaconToFollow = GameObject.Find("Tower").GetComponent<Renderer>();//tower
        }

        else if (beaconChooser == 4)
        {
            beaconToFollow = GameObject.Find("Tower1").GetComponent<Renderer>();//tower
        }
        else
        {
            beaconToFollow = GameObject.Find("Tower2").GetComponent<Renderer>();//tower
        }

        target = new Vector3(beaconToFollow.bounds.center.x, beaconToFollow.bounds.center.y - 10, beaconToFollow.bounds.center.z);
    }

    void Update()
    {
        if (beaconToFollow == null)
        {
            ChooseRandomBeacon();

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);

        }
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
        audioManager.PlaySFX(audioManager.TowertakeDamage);

    }
}
