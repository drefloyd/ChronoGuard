using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterTowerTeleport : MonoBehaviour
{
    public PlayerInput input;
    Vector3 teleportLocation;
    GameObject player;

    InputManager manager;

    GameObject[] towers; //create initial list of towers at start
    AudioManager audioManager;

    private void Awake()
    {
         towers = GameObject.FindGameObjectsWithTag("Tower");
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    /// <summary>
    /// Teleport player to top of the tower if he walks into the portal at the base
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get the coordinates for the top of the current tower i.e. the nearest one if there are multiple
            GameObject closestTower = null;
            int startTowerIndex = 0;
            foreach (GameObject tower in towers)
            {
                if (closestTower == null)
                {
                    closestTower = tower;
                    startTowerIndex = Array.IndexOf(towers, tower);
                }
                else
                {
                    float distanceToCurrentClosestTower = Vector3.Distance(collision.gameObject.transform.position, closestTower.transform.position);
                    float distanceToThisTower = Vector3.Distance(collision.gameObject.transform.position, tower.transform.position);

                    if (distanceToThisTower < distanceToCurrentClosestTower)
                    {
                        closestTower = tower;
                        startTowerIndex = Array.IndexOf(towers, tower);
                    }
                }

            }
            int targetTowerIndex = (startTowerIndex + 1) > towers.Length - 1 ? 0 : (startTowerIndex + 1);   //teleport to the next tower in the array, wrapping around to the 0th index

            try
            {
                //get the position to teleport to on the top of the tower
                float x = towers[targetTowerIndex].GetComponent<Renderer>().bounds.center.x;
                float z = towers[targetTowerIndex].GetComponent<Renderer>().bounds.center.z;

                float y = towers[targetTowerIndex].GetComponent<Renderer>().bounds.extents.y;

                //set the player's position to those coordinates, need to deactivate and reactivate it
                player = GameObject.Find("Player");
                manager = player.GetComponent<InputManager>();
                //+1.5 so not too close to that tower's portal
                teleportLocation = new Vector3(x + 1.5f, 40, z + 1.5f);   //hard code to height 40 because the bounds doesn't work for some reason
                audioManager.PlaySFX(audioManager.Teleport);
                StartCoroutine("Teleport");

            }
            catch (Exception e)
            {
                //If the tower no longer exists, should come here with a null reference exception and no teleport happens
                Debug.Log(e.ToString());
            }

        }

    }

    /// <summary>
    /// This is necessary due to timing, need to disable user input otherwise it gets confused and doesn't teleport. 
    /// And also need to wait for actual teleport to take place.
    /// </summary>
    /// <returns></returns>
    IEnumerator Teleport()
    {
        manager.disabled = true;
        yield return new WaitForSeconds(0.1f);
        player.transform.position = teleportLocation;
        yield return new WaitForSeconds(0.1f);
        manager.disabled = false;
    }
}
