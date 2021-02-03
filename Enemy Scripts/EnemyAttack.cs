using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damageAmount = 10f;
    public float DamageCount { get { return damageAmount; } set { damageAmount = value; } }

    private Transform playerTarget;
    private Animator anim;

    private bool finishedAttack = true;
    private float damageDistance = 2f;

    private PlayerStatus playerHealth;
    

    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

        playerHealth = playerTarget.GetComponent<PlayerStatus>();

    }

    void Update()
    {
        if (finishedAttack)
        {
            if (playerTarget)
            {
                DealDamage(CheckIfAttacking());
            }
            
        }
        else
        {
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                finishedAttack = true;
            }
        }
    }
    bool CheckIfAttacking()
    {
        bool isAttacking = false;

        //Checks if the player is attacking by checking if the attackanimation is in the middle of the animation and then sets
        //isAttacking to true which will deal damage.
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") 
            || anim.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                isAttacking = true;
                finishedAttack = false;
            }
        }

        return isAttacking;
    }
    void DealDamage(bool isAttacking)
    {
        if (isAttacking)
        {
            if (Vector3.Distance(transform.position, playerTarget.position) <= damageDistance)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
