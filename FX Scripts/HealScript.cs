using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{

    public float healAmount;
    private float procentAmount = 0.1f;
    public float ProcentAmount { get { return procentAmount; } set { procentAmount = value; } }

    //public static float HealAmount { get { return healAmount;} set { healAmount = value; } }

    PlayerStats player;
    PlayerStatus playerStatus;
    void Awake()
    {
        playerStatus = GameObject.Find("Black Knight").GetComponent<PlayerStatus>();
        player = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        healAmount = player.maxHealthPoints * ProcentAmount;
        print("CurrentHealAmount: " + healAmount);
        print(player.maxHealthPoints);

    }

    private void Update()
    {
        playerStatus.UpgradeHealthbar();
    }
    public void Healing()
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().HealPlayer(healAmount);
        print(player.maxHealthPoints);
    }

}
