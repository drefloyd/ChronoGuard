using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000f;//make sure to change it on the player too, if ypu want to modify speed.
    public Camera PlayerCam;

    public void shootBullet()
    {
        RaycastHit theHit;
        if(Physics.Raycast(PlayerCam.transform.position,PlayerCam.transform.forward,out theHit, Mathf.Infinity))
        {
            bulletSpawnPoint.rotation = Quaternion.LookRotation(theHit.point - bulletSpawnPoint.position); 
        }
        else
        {
            bulletSpawnPoint.rotation.Set(0, 0, 0, 0);
        }
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed);
    }
}
