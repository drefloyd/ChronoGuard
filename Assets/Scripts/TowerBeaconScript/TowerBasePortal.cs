using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBasePortal : MonoBehaviour
{
    public PlayerInput input;
    Vector3 teleportLocation;
    GameObject player;
    public int playerposition;
    public static GameObject towerposition;
    InputManager manager;

    //private void Awake()
    //{
    //    manager = GetComponent<InputManager>();
    //}

    /// <summary>
    /// Teleport player to top of the tower if he walks into the portal at the base
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get the coordinates for the top of the current tower i.e. the nearest one if there are multiple
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
            GameObject closestTower = null;
            foreach (GameObject tower in towers)
            {
                if (closestTower == null)
                {
                    closestTower = tower;
                    towerposition=closestTower;
                }
                else
                {
                    float distanceToCurrentClosestTower = Vector3.Distance(collision.gameObject.transform.position, closestTower.transform.position);
                    float distanceToThisTower = Vector3.Distance(collision.gameObject.transform.position, tower.transform.position);

                    if (distanceToThisTower < distanceToCurrentClosestTower)
                    {
                        closestTower = tower;

                    }
                }
                
            }

            try
            {
                //get the position to teleport to on the top of the tower
                float x = closestTower.GetComponent<Renderer>().bounds.center.x;
                float z = closestTower.GetComponent<Renderer>().bounds.center.z;

                float y = closestTower.GetComponent<Renderer>().bounds.extents.y;
                //set the player's position to those coordinates, need to deactivate and reactivate it
                player = GameObject.Find("Player");
                manager = player.GetComponent<InputManager>();
                teleportLocation = new Vector3(x, 40, z);   //hard code to height 40 because the bounds doesn't work for some reason
             
                StartCoroutine("Teleport");

            }
            catch (Exception e)
            {
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
