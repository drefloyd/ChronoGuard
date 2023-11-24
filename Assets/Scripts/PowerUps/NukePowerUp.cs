using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    scoreScript playerScoreScript;
    void Start()
    {
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
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
                //get score for each
                playerScoreScript.increaseScore();
            }
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
