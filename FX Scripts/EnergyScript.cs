using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    [SerializeField]
    public float currentEnergy;
  
    private float energyRegen = 20f;
    [SerializeField]
    public float EnergyRegen { get { return energyRegen; } set { energyRegen = value; } }

    private float maxEnergy = 100f;
    [SerializeField]
    public float MaxEnergy { get { return maxEnergy; } set { maxEnergy = value; } }

    private static Image energy_Img;

    private void Start()
    {
        energy_Img = GameObject.Find("Energy Icon").GetComponent<Image>();
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += EnergyRegen * Time.deltaTime;
            energy_Img.fillAmount = currentEnergy / maxEnergy;
        }
    }
    public void UseEnergy(float amount)
    {
        currentEnergy -= amount;
        if (currentEnergy <= 0f)
        {
            currentEnergy = 0f;
        }

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        energy_Img.fillAmount = currentEnergy / maxEnergy;
    }
}
