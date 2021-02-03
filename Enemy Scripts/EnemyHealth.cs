using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{

    public float currentHealth = 0f;
    private float maxHealth = 40;

    public Image health_Img;


    //REFERENCES
    Experience XP;
    PlayerStats playerstats;


    private void Awake()
    {
        XP = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Experience>();
        playerstats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {

        currentHealth -= amount;
        health_Img.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            XP.ExperienceGained(XP.expGainedWhenKilled);
            print("You Gained: " + XP.expGainedWhenKilled);
            print("Current Experience: " + playerstats.currentExperience);
            currentHealth = 0;

        }
    }

    
}


