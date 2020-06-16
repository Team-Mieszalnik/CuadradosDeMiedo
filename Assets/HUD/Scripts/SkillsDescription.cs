using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/**
    * @brief
    * klasa odpowiadajaca za wyswietlania opisow umiejetenosci do ulepszenia (tooltip)
*/
public class SkillsDescription : MonoBehaviour
{
    TextMeshProUGUI meshProUGUI;

    Experience experience;

    // Start is called before the first frame update
    void Start()
    {
        meshProUGUI = GetComponent<TextMeshProUGUI>();

        experience = GameObject.FindGameObjectWithTag("Hero").GetComponent<Experience>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void HealthLevel()
    {
        SkillsLevel(experience.healthLevel);
    }

    public void EnergyLevel()
    {
        SkillsLevel(experience.energyLevel);
    }

    public void MovementLevel()
    {
        SkillsLevel(experience.movementLevel);
    }

    public void CureLevel()
    {
        SkillsLevel(experience.cureLevel);
    }

    public void ArmorLevel()
    {
        SkillsLevel(experience.armorLevel);
    }

    protected void SkillsLevel(int skill)
    {
        switch(skill)
        {
            case 0:
                meshProUGUI.SetText("Level: 0");
                break;
            case 1:
                meshProUGUI.SetText("Level: 1");
                break;
            case 2:
                meshProUGUI.SetText("Level: 2");
                break;
            case 3:
                meshProUGUI.SetText("Level: 3");
                break;
            case 4:
                meshProUGUI.SetText("Level: 4");
                break;
            case 5:
                meshProUGUI.SetText("Level: 5");
                break;
        }
    }




    public void HealthCost()
    {
        SkillsCost(experience.healthLevel);
    }

    public void EnergyCostl()
    {
        SkillsCost(experience.energyLevel);
    }

    public void MovementCostl()
    {
        SkillsCost(experience.movementLevel);
    }

    public void CureCost()
    {
        SkillsCost(experience.cureLevel);
    }

    public void ArmorCost()
    {
        SkillsCost(experience.armorLevel);
    }

    protected void SkillsCost(int skill)
    {
        switch (skill)
        {
            case 0:
                meshProUGUI.SetText("Cost: 10");
                break;
            case 1:
                meshProUGUI.SetText("Cost: 19");
                break;
            case 2:
                meshProUGUI.SetText("Cost: 28");
                break;
            case 3:
                meshProUGUI.SetText("Cost: 37");
                break;
            case 4:
                meshProUGUI.SetText("Cost: 46");
                break;
            case 5:
                meshProUGUI.SetText("");
                break;
        }
    }




    public void HealthLevelDescription()
    {
        switch (experience.healthLevel)
        {
            case 0:
                meshProUGUI.SetText("max health +10");
                break;
            case 1:
                meshProUGUI.SetText("max health +10\nregeneration +0.2/s");
                break;
            case 2:
                meshProUGUI.SetText("max health +20\nregeneration +0.2/s");
                break;
            case 3:
                meshProUGUI.SetText("max health +20\nregeneration +0.2/s");
                break;
            case 4:
                meshProUGUI.SetText("max health +40\nregeneration +0.3/s");
                break;
            case 5:
                meshProUGUI.SetText("MAX LEVEL");
                break;
        }
    }

    public void EnergyLevelDescription()
    {
        switch (experience.energyLevel)
        {
            case 0:
                meshProUGUI.SetText("max energy +10");
                break;
            case 1:
                meshProUGUI.SetText("max energy +10\nregeneration +0.2/s");
                break;
            case 2:
                meshProUGUI.SetText("max energy +20\nregeneration +0.2/s");
                break;
            case 3:
                meshProUGUI.SetText("max energy +20\nregeneration +0.2/s");
                break;
            case 4:
                meshProUGUI.SetText("max energy +40\nregeneration +0.3/s");
                break;
            case 5:
                meshProUGUI.SetText("MAX LEVEL");
                break;
        }
    }

    public void MovementLevelDescription()
    {
        switch (experience.movementLevel)
        {
            case 0:
                meshProUGUI.SetText("sprint cost -1/s");
                break;
            case 1:
                meshProUGUI.SetText("sprint cost -1/s\nsprint power +0.5");
                break;
            case 2:
                meshProUGUI.SetText("sprint cost -1/s\nsprint power +0.5");
                break;
            case 3:
                meshProUGUI.SetText("sprint cost -1/s\nsprint power +0.5\nhero speed +0.4");
                break;
            case 4:
                meshProUGUI.SetText("sprint cost -1/s\nsprint power +0.5\nhero speed +0.6");
                break;
            case 5:
                meshProUGUI.SetText("MAX LEVEL");
                break;
        }
    }

    public void CureLevelDescription()
    {
        switch (experience.cureLevel)
        {
            case 0:
                meshProUGUI.SetText("cure cost -4");
                break;
            case 1:
                meshProUGUI.SetText("cure cost -4\ncure power +4");
                break;
            case 2:
                meshProUGUI.SetText("cure cost -4\ncure power +4");
                break;
            case 3:
                meshProUGUI.SetText("cure cost -4\ncure power +4\ncure delay -0.5");
                break;
            case 4:
                meshProUGUI.SetText("cure cost -4\ncure power +8\ncure delay -0.5");
                break;
            case 5:
                meshProUGUI.SetText("MAX LEVEL");
                break;
        }
    }

    public void ArmorLevelDescription()
    {
        switch (experience.armorLevel)
        {
            case 0:
                meshProUGUI.SetText("shield cost -0.4/s");
                break;
            case 1:
                meshProUGUI.SetText("shield cost -0.4/s\nshield reduction +0.5");
                break;
            case 2:
                meshProUGUI.SetText("shield cost -0.4/s\nshield reduction +0.5");
                break;
            case 3:
                meshProUGUI.SetText("shield cost -0.4/s\nbasic reduction +0.5");
                break;
            case 4:
                meshProUGUI.SetText("shield cost -0.4/s\nbasic reduction +0.5");
                break;
            case 5:
                meshProUGUI.SetText("MAX LEVEL");
                break;
        }
    }
}
