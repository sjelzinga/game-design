﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquirrelHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int healthInterval = 4;

    public HealthBar healthBar;
    public Text gameOver;
    private GameObject pickUpObj;


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
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            IncreaseHealth(10);
            StartCoroutine(RespawnPickUp(collision.gameObject, Random.Range(5,10)));

            //Invoke("RespawnPickUp", Random.Range(5, 10));
           
        }
    }

    private IEnumerator RespawnPickUp(GameObject gameObject, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

}
