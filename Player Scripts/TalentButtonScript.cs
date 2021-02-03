using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TalentButtonScript : MonoBehaviour
{
    public Button talent_Slot1;
    public Button talent_Slot2;

    public Text healAmountText;
    public Text talent_Slot2Text;
    private bool healSkillIsMaxedOut;
    private bool talent2SkillIsMaxedOut;
    private int amountNumber = 0;
    private int amountNumber1 = 0;


    //Reference
    Experience xp;
    PlayerStats playerStats;
    PlayerStatus playerHealth;
    SkillUpgrades skillUpgrades;
    SkillDamage damage;

    HealScript heal;

    private void Awake()
    {
        
    }
    void Start()
    {
        heal = GameObject.Find("Black Knight").GetComponent<HealScript>();
        skillUpgrades = GameObject.Find("Skill Tree Menu").GetComponent<SkillUpgrades>();
        healAmountText = healAmountText.GetComponent<Text>();
        talent_Slot2Text = talent_Slot2Text.GetComponent<Text>();
        Button btn = talent_Slot1.GetComponent<Button>();
        Button btn1 = talent_Slot2.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn1.onClick.AddListener(TalentSlot2Click);
        playerStats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        playerHealth = GameObject.Find("Black Knight").GetComponent<PlayerStatus>();
        // GameObject.Find("TalentManager").GetComponent<TalentButtonScript
    }

    void TaskOnClick()
    {
        if (playerStats.skillPoint >= 1 && healSkillIsMaxedOut == false && amountNumber == 0)
        {
            amountNumber++;
            talent_Slot1.image.color = Color.white;
            playerStats.skillPoint--;
            heal.ProcentAmount = 0.15f;
            skillUpgrades.HealUpgrade(heal.ProcentAmount);
        }

        else if (amountNumber == 1 && playerStats.skillPoint >= 1)
        {
            amountNumber++;
            healAmountText.color = Color.green;
            playerStats.skillPoint--;
            healSkillIsMaxedOut = true;
            heal.ProcentAmount = 0.20f;
            skillUpgrades.HealUpgrade(heal.ProcentAmount);
        }

        healAmountText.text = $"{amountNumber}/2";
        
    }

    void TalentSlot2Click()
    {
        if (healSkillIsMaxedOut == true && playerStats.skillPoint >= 1 && amountNumber1 == 0 && talent2SkillIsMaxedOut == false)
        {
            amountNumber1++;
            talent_Slot2.image.color = Color.white;
            playerStats.skillPoint--;
            skillUpgrades.Phrases("YAY LEVEL !");
            Debug.Log("LEVEL 1");
        }

        else if (playerStats.skillPoint >= 1 && amountNumber1 == 1)
        {
            amountNumber1++;
            playerStats.skillPoint--;
            talent2SkillIsMaxedOut = true;
            skillUpgrades.Phrases("IM SO GOOD AT THIS!");
            Debug.Log("LEVEL 2");
        }

        else if (playerStats.skillPoint >= 1 && amountNumber1 == 2)
        {
            amountNumber1++;
            talent_Slot2Text.color = Color.green;
            playerStats.skillPoint--;
            talent2SkillIsMaxedOut = true;
            skillUpgrades.Phrases("REALLY? CMON GET ME!");
            Debug.Log("LEVEL 3");
        }
        talent_Slot2Text.text = $"{amountNumber1}/3";
    }
}
