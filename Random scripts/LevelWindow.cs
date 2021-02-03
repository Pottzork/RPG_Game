using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private LevelSystem levelSystem;
    

    void Awake()
    {
        levelText = transform.Find("LevelText").GetComponent<Text>();
        experienceBarImage = transform.Find("ExperienceBar").Find("XP").GetComponent<Image>();

    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level: " + (levelNumber +1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        //Set the LevelSYstem Object
        this.levelSystem = levelSystem;

        //Update the starting values
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        // Subscribe to the changed events
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //Level changed Update text
        SetLevelNumber(levelSystem.GetLevelNumber());
    }
    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        //Experience changed, update bar size
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
}
