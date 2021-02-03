using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTree : MonoBehaviour
{
    public TextMeshProUGUI skillPointText;
    public Canvas skillTreeMenu;
    PlayerStats playerStats;
    public bool showTalents = false;

    void Start()
    {
        playerStats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        skillTreeMenu.enabled = false;
        skillPointText = skillPointText.GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        skillPointText.text = $"Skill point:\n{playerStats.skillPoint}";

        if (Input.GetKeyDown(KeyCode.N))
        {

            ToggleSkillTree();
            
        }

    }
    public void ToggleSkillTree()
    {
        showTalents = !showTalents;
        skillTreeMenu.enabled = showTalents;

    }

}
