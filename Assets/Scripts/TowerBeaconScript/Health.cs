using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;
    public string playerTag;
    public static string winnerString;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth<=0 && playerTag == "Player1")
        {
            winnerString = "PLAYER 2";
            SceneManager.LoadSceneAsync(2);
        }
        else if (currentHealth <= 0 && playerTag == "Player2")
        {
            winnerString = "PLAYER 1";
            SceneManager.LoadSceneAsync(2);
        }
    }
    public void AddHealth(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth>maxHealth)
        {
            currentHealth=maxHealth;
        }
    }
}
