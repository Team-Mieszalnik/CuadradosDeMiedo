using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Experience : MonoBehaviour
{
    public static int DefeatedOpponents { get; private set; }

    public static int points;
    private int upgradeCost = 10;

    [HideInInspector]
    public int healthLevel;
    [HideInInspector]
    public int energyLevel;
    [HideInInspector]
    public int movementLevel;
    [HideInInspector]
    public int cureLevel;
    [HideInInspector]
    public int armorLevel;

    [HideInInspector]
    public int healthMaxLevel = 5;
    [HideInInspector]
    public int energyhMaxLevel = 5;
    [HideInInspector]
    public int movementMaxLevel = 5;
    [HideInInspector]
    public int cureMaxLevel = 5;
    [HideInInspector]
    public int armorMaxLevel = 5;


    private Hero hero;
    private Skills skills;


    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<Hero>();
        skills = GetComponent<Skills>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addDefeatedOpponents(int number)
    {
        DefeatedOpponents += number;
        points += number;
    }


    public bool CanHealthUpgrade()
    {
        return ((points >= upgradeCost) && (healthLevel < healthMaxLevel));
    }

    public bool CanEnergyUpgrade()
    {
        return ((points >= upgradeCost) && (energyLevel < energyhMaxLevel));
    }

    public bool CanMovementUpgrade()
    {
        return (points >= upgradeCost && movementLevel < movementMaxLevel);
    }

    public bool CanCureUpgrade()
    {
        return (points >= upgradeCost && cureLevel < cureMaxLevel);
    }

    public bool CanArmorUpgrade()
    {
        return (points >= upgradeCost && armorLevel < armorMaxLevel);
    }



    public void HealthLevelUpgrade()
    {
        if (CanHealthUpgrade()) 
        {
            if (healthLevel == 0) 
            {
                hero.health += 10;
            }
            if (healthLevel == 1)
            {
                hero.healthRegeneration += (float)0.1;
            }
            if (healthLevel == 2)
            {
                hero.health += 20;
            }
            if (healthLevel == 3)
            {
                hero.healthRegeneration += (float)0.2;
            }
            if (healthLevel == 4)
            {
                hero.health += 20;
                hero.healthRegeneration += (float)0.2;
            }

            healthLevel++;
            points -= upgradeCost;
        }
    }


    public void EnergyLevelUpgrade()
    {
        if (CanEnergyUpgrade())
        {
            if (energyLevel == 0)
            {
                hero.energy += 10;
            }
            if (energyLevel == 1)
            {
                hero.energyRegeneration += (float)0.2;
            }
            if (energyLevel == 2)
            {
                hero.energy += 20;
            }
            if (energyLevel == 3)
            {
                hero.energyRegeneration += (float)0.3;
            }
            if (energyLevel == 4)
            {
                hero.energy += 20;
                hero.energyRegeneration += (float)0.3;
            }

            energyLevel++;
            points -= upgradeCost;
        }
    }

    public void MovementLevellUpgrade()
    {
        if (CanMovementUpgrade())
        {
            if (movementLevel == 0)
            {
                skills.sprintEnergy -= 1;
            }
            if (movementLevel == 1)
            {
                skills.sprintEnergy -= 1;
                skills.sprintPower += 0.5f;
            }
            if (movementLevel == 2)
            {
                skills.sprintEnergy -= 1;
                skills.sprintPower += 0.5f;
            }
            if (movementLevel == 3)
            {
                skills.sprintEnergy -= 1;
                hero.speed += 0.5f;
            }
            if (movementLevel == 4)
            {
                skills.sprintEnergy -= 1;
                skills.sprintPower += 0.5f;
                hero.speed += 0.5f;
            }

            movementLevel++;
            points -= upgradeCost;
        }
    }

    public void CureLevellUpgrade()
    {
        if (CanCureUpgrade())
        {
            if (cureLevel == 0)
            {
                skills.cureEnergy -= 2;
            }
            if (cureLevel == 1)
            {
                skills.cureEnergy -= 2;
                skills.curePower += 2;
            }
            if (cureLevel == 2)
            {
                skills.cureEnergy -= 2;
                skills.curePower += 2;
            }
            if (cureLevel == 3)
            {
                skills.cureEnergy -= 2;
                skills.curePower += 2;
                skills.cureDelay -= 0.5f;
            }
            if (cureLevel == 4)
            {
                skills.cureEnergy -= 2;
                skills.curePower += 4;
                skills.cureDelay -= 0.5f;
            }

            cureLevel++;
            points -= upgradeCost;
        }
    }

    public void ArmorLevellUpgrade()
    {
        if (CanArmorUpgrade())
        {
            if (armorLevel == 0)
            {
                skills.defenseEnergy -= 0.5f;
            }
            if (armorLevel == 1)
            {
                skills.defenseEnergy -= 0.5f;
                skills.defensePower += 0.5f;
            }
            if (armorLevel == 2)
            {
                skills.defenseEnergy -= 0.5f;
                skills.defensePower += 0.5f;
            }
            if (armorLevel == 3)
            {
                skills.defenseEnergy -= 0.5f;
                skills.defensePower += 1f;
            }
            if (armorLevel == 4)
            {
                skills.defenseEnergy -= 0.5f;
                skills.defensePower += 2f;
            }

            armorLevel++;
            points -= upgradeCost;
        }
    }


}
