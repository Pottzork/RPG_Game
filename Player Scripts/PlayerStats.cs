using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [Header("Main Player Stats")]
    
    public float healthPoints;
    public float maxHealthPoints = 100f;
    private float agility = 1.2f;
    private float strength = 1.2f;
    private float stamina = 1.2f;
    private float intellect = 1.2f;
    public float Agility { get { return agility; } set { agility = value; } }
    public float Strenght { get { return strength; } set { strength = value; } }
    public float Stamina { get { return stamina; } set { stamina = value; } }
    public float Intellect { get { return intellect; } set { intellect = value; } }



    [HideInInspector]
    public float currentExperience = 0;
    [HideInInspector]
    public float previousExperience;
    [HideInInspector]
    public float XPNeededForLevelUp = 100f;

    [HideInInspector]
    public int skillPoint = 0;
    [HideInInspector]
    public float currentLevel = 1;

    PlayerStatus playerStatus;
    private void Awake()
    {
        playerStatus = GameObject.Find("Black Knight").GetComponent<PlayerStatus>();       
        maxHealthPoints *= Stamina;
        healthPoints = maxHealthPoints;
        playerStatus.UpgradeHealthbar();
    }

    private void Start()
    {
        
    }

}

