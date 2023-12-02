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
    private int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    AudioManager audioManager;

    void Start()
    {
        if (gameObject.CompareTag("Tower"))
        {
            maxHealth = 5;
        }
        else
        {
            maxHealth = 5;
        }
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        GetCurrentHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(explosion, collision.transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("Drone"))
        {
            TakeDamage(1);
            audioManager.PlaySFX(audioManager.TowertakeDamage);
        }
    }

    private void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
    public int GetCurrentHealth()
    {
        //Debug.Log("Current Health: " + currentHealth);
        return currentHealth;
    }

}
