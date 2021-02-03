using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDamage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    
    [SerializeField]
    private float damageCount = 100f;
    public float DamageCount { get { return damageCount; } set { damageCount = value; } }



    private EnemyHealth enemyHealth;
    private bool collided;
    [Header("CRIT CHANCE AND CRIT DAMAGE")]
    [SerializeField] 
    private float maxCritX = 3.5f;
    public float MaxCritX { get { return maxCritX; } set { maxCritX = value; } }
    [SerializeField]
    private float minCritX = 1.25f;
    public float MinCritX { get { return minCritX; } set { minCritX = value; } }
    [SerializeField]
    private float critChance = 0.10f;
    public float CritChance { get { return critChance; } set { critChance = value; } }


    //----------------------------------------------------------------
    // Funkar ej att koppla detta till PlayerAttackEffects!
    [SerializeField]
    private static float energyCost;
    public static float EnergyCost { get { return energyCost; } set { energyCost = value; } }
   
    //----------------------------------------------------------------





    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach(Collider c in hits)
        {
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;

            if (collided)
            {
                DamageCount += CalculateCritChance(DamageCount);
                enemyHealth.TakeDamage(DamageCount);
                print($"Enemy TOOK {DamageCount} damage.");
                enabled = false;
            }
        }
    }

    public float CalculateCritChance(float damage)
    {
        if(Random.value <= critChance)
        {
            float critDamage = damage * Random.Range(minCritX, maxCritX);
            return critDamage;
        }
        return 0;
    }




}







