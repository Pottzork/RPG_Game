using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject groundImpact_Spawn, kickFX_Spawn, fireTornado_Spawn, fireShield_Spawn, cursor_Spawn, SwordAtk_Spawn;
    public GameObject groundImpact_Prefab, kickFX_Prefab, fireTornado_Prefab, fireShield_Prefab,
        healFX_Prefab, thunderFX_Prefab, SwordAttack_Prefab;
    //Lägg till ARRAY med olika Skills
    PlayerStats playerStats;
    HealScript healScript;
    private void Awake()
    {
        healScript = GameObject.Find("Black Knight").GetComponent<HealScript>();
        playerStats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
    }

    private void Start()
    {
    
    }
    void GroundImpact()
    {
        if (playerStats.currentLevel >= 2)
        {
            
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 40f;
            EnergyScript Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost)
            {

                return;
            }
            Energy.UseEnergy(energyCost);
            Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity);
        }
        
    }


    void Kick()
    {
        if (playerStats.currentLevel >= 4)
        {
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 10f;
            var Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost) return;
            Energy.UseEnergy(energyCost);
            Instantiate(kickFX_Prefab, kickFX_Spawn.transform.position, Quaternion.identity);
        }
        
    }
    void FireTornado()
    {
        if (playerStats.currentLevel >= 6)
        {
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 70f;
            var Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost) return;
            Energy.UseEnergy(energyCost);
            Instantiate(fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity);
        }
        
    }
    void FireShield()
    {
        if(playerStats.currentLevel >= 8)
        {
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 10f;
            var Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost) return;
            Energy.UseEnergy(energyCost);
            GameObject fireObj = Instantiate(fireShield_Prefab, fireShield_Spawn.transform.position,
                Quaternion.identity) as GameObject;

            fireObj.transform.SetParent(transform);
        }
        else
        {
            return;
        }
       
    }
    void Heal()
    {
        if (playerStats.currentLevel >= 3)
        {
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 50f;
            var Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost) return;
            Energy.UseEnergy(energyCost);
            Vector3 temp = transform.position;
            temp.y += 2f;
            GameObject healObj = Instantiate(healFX_Prefab, temp, Quaternion.identity) as GameObject;
            healObj.transform.SetParent(transform);
            healScript.Healing();
        }
        
    }
    void SwordAttack()
    {

        Instantiate(SwordAttack_Prefab, SwordAtk_Spawn.transform.position, Quaternion.identity);
    }

    void ThunderAttack()
    { 
        if(playerStats.currentLevel >= 10)
        {
            var energyCost = SkillDamage.EnergyCost;
            energyCost = 90f;
            var Energy = FindGameObject();
            if (Energy.currentEnergy < energyCost) return;
            Energy.UseEnergy(energyCost);
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = Vector3.zero;

                if (i == 0)
                {
                    pos = new Vector3(transform.position.x - 4f, transform.position.y + 0,
                        transform.position.z);
                }
                else if (i == 1)
                {
                    pos = new Vector3(transform.position.x + 4f, transform.position.y + 0,
                        transform.position.z);
                }
                else if (i == 2)
                {
                    pos = new Vector3(transform.position.x, transform.position.y + 0f,
                        transform.position.z - 4f);
                }
                else if (i == 3)
                {
                    pos = new Vector3(transform.position.x, transform.position.y + 0f,
                        transform.position.z + 4f);
                }
                else if (i == 4)
                {
                    pos = new Vector3(transform.position.x + 2.5f, transform.position.y + 0f,
                        transform.position.z + 2.5f);
                }
                else if (i == 5)
                {
                    pos = new Vector3(transform.position.x - 2.5f, transform.position.y + 0f,
                        transform.position.z + 2.5f);
                }
                else if (i == 6)
                {
                    pos = new Vector3(transform.position.x - 2.5f, transform.position.y + 0f,
                        transform.position.z - 2.5f);
                }
                else if (i == 7)
                {
                    pos = new Vector3(transform.position.x + 2.5f, transform.position.y + 0f,
                        transform.position.z + 2.5f);
                }

                Instantiate(thunderFX_Prefab, pos, Quaternion.identity);
            }
        }
        
    }

    private static EnergyScript FindGameObject()
    {
        return GameObject.Find("Black Knight").GetComponent<EnergyScript>();
    }

} //class



















