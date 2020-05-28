using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class SquirrelHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int healthInterval = 4;

    public HealthBar healthBar;
    public Text gameOver;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        DecreaseHealthOnTime();
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DecreaseHealth(int health)
    {
        currentHealth -= health;

        healthBar.SetHealth(currentHealth);
    }

    public void IncreaseHealth(int health)
    {
        currentHealth += health;

        healthBar.SetHealth(currentHealth);
    }

    void ResetHealth()
    {
        healthBar.SetHealth(maxHealth);
    }

    void DecreaseHealthOnTime()
    {
        if(currentHealth > 0)
        {
            DecreaseHealth(healthInterval);
            Invoke("DecreaseHealthOnTime", 1.0f);
        }
        else
        {
            gameOver.gameObject.SetActive(true);
        }
    }

}
