using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    public GameObject explode;
    scoreScript playerScoreScript;
    AudioManager audioManager;

    void Start()
    {
        playerScoreScript = GameObject.Find("Score").GetComponent<scoreScript>();
        Destroy(gameObject, 3);//only lasts 3 seconds
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
            audioManager.PlaySFX(audioManager.explosion);
        }
    }
}
