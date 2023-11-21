using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public LayerMask invisBarriers;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000f;   //make sure to change it on the player too, if ypu want to modify speed.
    public Camera PlayerCam;
    private float shootTime = 0f;
    private float canShootDelay = 0.2f;

    public void shootBullet()
    {
        if (Time.time > canShootDelay + shootTime)
        {
            shootTime = Time.time;
            RaycastHit theHit;
            if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out theHit, Mathf.Infinity,~invisBarriers))
            {
                //added this distance check because if you shoot the ground it looks weird if the laser flies off at an angle
                var distance = Vector3.Distance(theHit.point, bulletSpawnPoint.position);               
                if (distance > 3)
                {
                    bulletSpawnPoint.rotation = Quaternion.LookRotation(theHit.point - bulletSpawnPoint.position);
                }
                else
                {
                    bulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
                }
            }
            else
            {
                //Set did not seem to work so rotation only reset after there was another hit
                //bulletSpawnPoint.rotation.Set(0, 0, 0, 0);
                //below method seems to reset it better
                bulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
            }
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed);
        }
    }
}
