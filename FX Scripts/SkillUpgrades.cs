using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrades : MonoBehaviour
{
    public Image power1_slot, power2_slot, power3_slot, power4_slot, power5_slot, power6_slot;
    public GameObject healprefab;

    HealScript heal;
    PlayerStats player;
    void Awake()
    {
        power1_slot.GetComponent<Image>();

        power1_slot.color = Color.gray;
        power2_slot.color = Color.gray;
        power3_slot.color = Color.gray;
        power4_slot.color = Color.gray;
        power5_slot.color = Color.gray;
        power6_slot.color = Color.gray;
        heal = GameObject.Find("Black Knight").GetComponent<HealScript>();
        
        player = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
    }

    public float HealUpgrade(float amount)
    {
        heal.healAmount = amount * player.maxHealthPoints;
        return heal.healAmount;
    }
    public void Phrases(string WORDS)
    {
        print(WORDS);  
    }
}
