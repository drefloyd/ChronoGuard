using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;

public class BeaconScript : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(explosion, collision.transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("Drone"))
        {
            TakeDamage(1);
        }

    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
       
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }


}
