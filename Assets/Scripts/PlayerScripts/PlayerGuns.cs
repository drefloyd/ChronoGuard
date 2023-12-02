using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public Transform rightBulletSpawnPoint;
    public Transform leftBulletSpawnPoint;

    public GameObject rightBulletPrefab;
    public GameObject leftBulletPrefab;

    public LayerMask invisBarriers;
    private float bulletSpeed = 20000f;   
    public Camera PlayerCam;

    private float shootTime = 0f;
    private float canShootDelay = 0.0f;
    private float kickbackDistance = .4f;    // how far gun kicks back
    private float kickbackDelay = .07f;      // how long after kickback to reset the guns position back to the original 

    private bool shootRightGunNext = true;

    private Vector3 leftGunOrigPos;
    private Vector3 rightGunOrigPos;
    AudioManager audioManager;


    private void Start()
    {
        // Store the original position of the guns.
        rightGunOrigPos = GameObject.Find("rightGun").GetComponent<Transform>().localPosition;
        leftGunOrigPos = GameObject.Find("leftGun").GetComponent<Transform>().localPosition;
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    public void shootBullet()
    {

        if (pauseMenu.gameisPaused==false)
        {
            if (shootRightGunNext == true)
            {
                audioManager.PlaySFX(audioManager.bullet);

                if (Time.time > canShootDelay + shootTime)      // shoot right gun
                {
                    shootTime = Time.time;
                    RaycastHit theHit;
                    if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out theHit, Mathf.Infinity, ~invisBarriers))
                    {
                        //added this distance check because if you shoot the ground it looks weird if the laser flies off at an angle
                        var distance = Vector3.Distance(theHit.point, rightBulletSpawnPoint.position);
                        if (distance > 3)
                        {
                            rightBulletSpawnPoint.rotation = Quaternion.LookRotation(theHit.point - rightBulletSpawnPoint.position);
                        }
                        else
                        {
                            rightBulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
                        }
                    }
                    else
                    {
                        //Set did not seem to work so rotation only reset after there was another hit
                        //bulletSpawnPoint.rotation.Set(0, 0, 0, 0);
                        //below method seems to reset it better
                        rightBulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
                    }
                    var bullet = Instantiate(rightBulletPrefab, rightBulletSpawnPoint.position, rightBulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(rightBulletSpawnPoint.forward * bulletSpeed);

                    GameObject.Find("rightGun").GetComponent<Transform>().localPosition -= Vector3.forward * kickbackDistance;
                    StartCoroutine(ResetRightGunPosition());     // time until reset back to original position

                    shootRightGunNext = false;
                }
            }
            else
            {
                if (Time.time > canShootDelay + shootTime)  // shoot left gun
                {
                    audioManager.PlaySFX(audioManager.bullet);
                    shootTime = Time.time;
                    RaycastHit theHit;
                    if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out theHit, Mathf.Infinity, ~invisBarriers))
                    {
                        //added this distance check because if you shoot the ground it looks weird if the laser flies off at an angle
                        var distance = Vector3.Distance(theHit.point, leftBulletSpawnPoint.position);
                        if (distance > 3)
                        {
                            leftBulletSpawnPoint.rotation = Quaternion.LookRotation(theHit.point - leftBulletSpawnPoint.position);
                        }
                        else
                        {
                            leftBulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
                        }
                    }
                    else
                    {
                        //Set did not seem to work so rotation only reset after there was another hit
                        //bulletSpawnPoint.rotation.Set(0, 0, 0, 0);
                        //below method seems to reset it better
                        leftBulletSpawnPoint.rotation = Quaternion.LookRotation(PlayerCam.transform.forward);
                    }
                    var bullet = Instantiate(leftBulletPrefab, leftBulletSpawnPoint.position, leftBulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(leftBulletSpawnPoint.forward * bulletSpeed);

                    GameObject.Find("leftGun").GetComponent<Transform>().localPosition -= Vector3.forward * kickbackDistance;
                    StartCoroutine(ResetLeftGunPosition());     // time until reset back to original position

                    shootRightGunNext = true;
                }
            }
        }
    }

    IEnumerator ResetLeftGunPosition()
    {
        yield return new WaitForSeconds(kickbackDelay); // Adjust the delay as needed.
        GameObject.Find("leftGun").GetComponent<Transform>().localPosition = leftGunOrigPos;
    }

    IEnumerator ResetRightGunPosition()
    {
        yield return new WaitForSeconds(kickbackDelay);
        GameObject.Find("rightGun").GetComponent<Transform>().localPosition = rightGunOrigPos;
    }
}
