using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    IDLE,
    WALK,
    RUN,
    PAUSE,
    GOBACK,
    ATTACK,
    DEATH
}

public class EnemyController : MonoBehaviour
{
    //Distance controlling
    private float attack_Distance = 1.5f;
    public float alert_Attack_Distance = 8f;
    public float followDistance = 15f;
 

    private float enemyToPlayerDistance = 0;

    [HideInInspector]
    public EnemyState enemy_CurrentState = EnemyState.IDLE;
    private EnemyState enemy_LastState = EnemyState.IDLE;


    private Transform playerTarget;
    public Transform PlayerTarget { get { return playerTarget; } set { playerTarget = value; } }
    public GameObject playerPrefab;
    private Vector3 initialPosition;

    //private float move_Speed = 2f;
    //private float walk_Speed = 1f;

    public CharacterController charController;
    private Vector3 whereTo_Move = Vector3.zero;

    //Attack variable
    private float currentAttackTime;
    private float waitAttackTime = 1f;

    //Animation variable
    private Animator anim;
    public Animator Anim { get { return anim; } set { anim = value; } }
    private bool finished_Animation = true;
    private bool finished_Movement = true;

    private NavMeshAgent navAgent;
    public NavMeshAgent NavAgent { get { return navAgent; } set { navAgent = value; } }
    private Vector3 whereTo_Navigate;

    private EnemyHealth enemyHealth;

    //Health script


    void Awake()
    {
        //xp = GetComponent<Experience>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        initialPosition = transform.position;
        whereTo_Navigate = transform.position;

        enemyHealth = GetComponent<EnemyHealth>();
        
    }

    
    void Update()
    {
        if (enemyHealth.currentHealth <= 0f)
        {
            enemy_CurrentState = EnemyState.DEATH;
            
        }

        // if health is  <= 0 we will set the state to death
        if (enemy_CurrentState != EnemyState.DEATH)
        {
            enemy_CurrentState = SetEnemyState(enemy_CurrentState, enemy_LastState, enemyToPlayerDistance);
            if (finished_Movement)
            {
                GetStateControl(enemy_CurrentState);
            }
            else
            {
                if (!anim.IsInTransition(0) &&  anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    finished_Movement = true;
                }
                else if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsTag("Atk1")
                    || anim.GetCurrentAnimatorStateInfo(0).IsTag("Atk2"))
                {
                    anim.SetInteger("Atk", 0);
                }
            }
        } else
        {
            anim.SetBool("Death", true);
            charController.enabled = false;
            navAgent.enabled = false;
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
            {
                
                Destroy(gameObject, 2f);
                //xp.GainExperience(10f);
                //xp.XpGained = true;

            }
        }
    }
    //Controls the enemy behavior depending on distance. 
    EnemyState SetEnemyState(EnemyState curState, EnemyState lastState, float enemyToPlayerDis)
    {
        
        if(playerTarget != null)
        {
            enemyToPlayerDis = Vector3.Distance(transform.position, playerTarget.position);
        }
       
        
        
        float initialDistance = Vector3.Distance(initialPosition, transform.position);

        if (initialDistance > followDistance)
        {
            lastState = curState;
            curState = EnemyState.GOBACK; 
        }
        else if (enemyToPlayerDis <= attack_Distance) //Enemy attacks if it's in range of attack
        {
            lastState = curState;
            curState = EnemyState.ATTACK;
        }
        else if (enemyToPlayerDis >= alert_Attack_Distance && lastState == EnemyState.PAUSE
            || lastState == EnemyState.ATTACK)
        {
            lastState = curState;
            curState = EnemyState.PAUSE;
        }
        else if (enemyToPlayerDis <= alert_Attack_Distance && enemyToPlayerDis > attack_Distance)
        {
            if (curState != EnemyState.GOBACK || lastState == EnemyState.WALK)
            {
                lastState = curState;
                curState = EnemyState.PAUSE;
            }
        }
        else if (enemyToPlayerDis > alert_Attack_Distance && lastState != EnemyState.GOBACK &&
            lastState != EnemyState.PAUSE)
        {
            lastState = curState;
            curState = EnemyState.WALK;
        }
        return curState;
    }
    void GetStateControl(EnemyState curState)
    {
        if (curState == EnemyState.RUN || curState == EnemyState.PAUSE)
        {
            if (curState != EnemyState.ATTACK)
            {
                //Targets the player and runs towards him
                Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y,
                    playerTarget.position.z);
                if (Vector3.Distance(transform.position, targetPosition) >= 2.1f)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", true);

                    navAgent.SetDestination(targetPosition);
                }
            }
        }
        else if (curState == EnemyState.ATTACK && PlayerStatus.playerIsDead == false)
        {
            anim.SetBool("Run", false);
            whereTo_Move.Set(0f, 0f, 0f);

            navAgent.SetDestination(transform.position);
            if(playerTarget != null)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerTarget.position -
                transform.position), 5f * Time.deltaTime);
            }
            

            if (currentAttackTime >= waitAttackTime)
            {
                int atkRange = Random.Range(1, 3);
                anim.SetInteger("Atk", atkRange);
                finished_Animation = false;
                currentAttackTime = 0f;
            }
            else
            {
                anim.SetInteger("Atk", 0);
                currentAttackTime += Time.deltaTime;
            }
        }
        //This makes the enemy go back to it's original patrol location and 
        //when it's close to it, the enemy will start to walk
        else if (curState == EnemyState.GOBACK)
        {
            anim.SetBool("Run", true);
            Vector3 targetPosition = new Vector3(initialPosition.x, transform.position.y, initialPosition.z);

            navAgent.SetDestination(targetPosition);
            

            if (Vector3.Distance(targetPosition, initialPosition) <= 3.5f)
            {
                enemy_LastState = curState;
                curState = EnemyState.WALK;
                
            }
        }
        //Randomises the walk path for the enemy
        else if (curState == EnemyState.WALK)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);

            if (Vector3.Distance(transform.position, whereTo_Navigate) <= 2f)
            {
                whereTo_Navigate.x = Random.Range(initialPosition.x - 5f, initialPosition.x + 5f);
                whereTo_Navigate.z = Random.Range(initialPosition.z - 5f, initialPosition.z + 5f);

            }
            else
            {
                navAgent.SetDestination(whereTo_Navigate);
                
            }
        }
        //If the enemy is dead
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
            whereTo_Move.Set(0f, 0f, 0f);
            navAgent.isStopped = true;
        }
    }
}
