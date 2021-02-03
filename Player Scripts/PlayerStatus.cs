using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private bool isShielded;

    private Animator anim;
    private Transform playerTarget;
    private bool isAlive = true;

    private Image health_Img;
    PlayerStats playerStats;
    

    public static bool playerIsDead = false;



    public bool Alive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
        }
    }

    private void Awake()
    {
        playerStats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        playerStats.healthPoints = playerStats.maxHealthPoints;
        anim = GetComponent<Animator>();
        health_Img = GameObject.Find("Health Icon").GetComponent<Image>();
        
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public bool Shielded
    {
        get
        {
            return isShielded;
        }
        set
        {
            isShielded = value;
        }
    }
    public void TakeDamage(float amount)
    {
        if (!isShielded)
        {
            
            playerStats.healthPoints -= amount;

            health_Img.fillAmount = playerStats.healthPoints / playerStats.maxHealthPoints;
            print($"Player has {playerStats.healthPoints} health remaining");

            if (playerStats.healthPoints <= 0)
            {
                playerStats.healthPoints = 0;
                playerIsDead = true;
                anim.SetBool("Death", true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                Destroy(gameObject, 6f);
                //if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                //    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
                //{
                //    isAlive = false;
                //    Destroy(gameObject, 1f);
                //}
            }
        }
    }

       
    public void HealPlayer(float healAmount)
    {
        playerStats.healthPoints += healAmount; // 150 (BaseHP + 50 från healsscript.
        
        if (playerStats.healthPoints > playerStats.maxHealthPoints) // Efter heal och om healpoints > maxhealthpoints.
        {
            playerStats.healthPoints = playerStats.maxHealthPoints;
        }
        print($"extra healing: {healAmount}");
        UpgradeHealthbar();
    }

    public void UpgradeHealthbar()
    {
        health_Img.fillAmount = playerStats.healthPoints / playerStats.maxHealthPoints;
    }
}
