using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    private Image xpImage;
    private Text levelText;
    private Text showExperience;

    public float expGainedWhenKilled = 50f;


    //REFERENCES
    PlayerStats playerstats;
    PlayerStatus playerStatus;
    SkillUpgrades unlockSkills;
    HealScript heal;

    void Awake()
    {
        playerStatus = GameObject.Find("Black Knight").GetComponent<PlayerStatus>();
        heal = GameObject.Find("Black Knight").GetComponent<HealScript>();
        unlockSkills = GameObject.Find("Skill Tree Menu").GetComponent<SkillUpgrades>();
        showExperience = GameObject.Find("showExperience").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        playerstats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        xpImage = GameObject.Find("XP").GetComponent<Image>();
    }

    void Update()
    {
        showExperience.text = $"{playerstats.currentExperience} / {playerstats.XPNeededForLevelUp}";
        xpImage.fillAmount = playerstats.currentExperience / playerstats.XPNeededForLevelUp;
        playerStatus.UpgradeHealthbar();
    }


    public float ExperienceGained(float amountOfXp)
    {

        playerstats.currentExperience += amountOfXp;
        LevelUp();
        return playerstats.currentExperience;
    }

    public void LevelUp()
    {
        if (playerstats.currentExperience >= playerstats.XPNeededForLevelUp)
        {
            playerstats.maxHealthPoints *= playerstats.Stamina;
            heal.healAmount = playerstats.maxHealthPoints * heal.ProcentAmount; //Lägga till variabel istället för hårdkodat. variabeln updateras.
            playerstats.currentLevel++;
            unlockSkillsOnBar();
            playerstats.skillPoint++;
            
            
            playerstats.previousExperience = playerstats.currentExperience - playerstats.XPNeededForLevelUp;           
            playerstats.XPNeededForLevelUp += 300f;
            playerstats.currentExperience = playerstats.previousExperience;

            //Om currentExp fortfarande är mer än xpbarens max. Kör Metoden igen.
            if (playerstats.currentExperience >= playerstats.XPNeededForLevelUp) LevelUp();
            levelText.text = "Level: " + playerstats.currentLevel;

            playerStatus.UpgradeHealthbar();
        }
        else return;
    }

    public void unlockSkillsOnBar()
    {
        if (playerstats.currentLevel >= 2)
        {
            unlockSkills.power1_slot.color = Color.white;
        }
        if (playerstats.currentLevel >= 4)
        {
            unlockSkills.power2_slot.color = Color.white;
        }
        if (playerstats.currentLevel >= 6)
        {
            unlockSkills.power3_slot.color = Color.white;
        }
        if (playerstats.currentLevel >= 8)
        {
            unlockSkills.power4_slot.color = Color.white;
        }
        if (playerstats.currentLevel >= 3)
        {
            unlockSkills.power5_slot.color = Color.white;
        }
        if (playerstats.currentLevel >= 10)
        {
            unlockSkills.power6_slot.color = Color.white;
        }
    }
}

