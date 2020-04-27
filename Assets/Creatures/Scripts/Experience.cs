using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Experience : MonoBehaviour
{
    public static int DefeatedOpponents { get; private set; }

    public static int points;

    private int healthUpgradeCost = 10;
    private int energyUpgradeCost = 10;
    private int movementUpgradeCost = 10;
    private int cureUpgradeCost = 10;
    private int armorUpgradeCost = 10;

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
        DefeatedOpponents++;
        points += number;
    }

    public static void ResetDefeatedOpponents()
    {
        DefeatedOpponents = 0;
        points = 0;
    }


    public bool CanHealthUpgrade()
    {
        return ((points >= healthUpgradeCost) && (healthLevel < healthMaxLevel));
    }

    public bool CanEnergyUpgrade()
    {
        return ((points >= energyUpgradeCost) && (energyLevel < energyhMaxLevel));
    }

    public bool CanMovementUpgrade()
    {
        return (points >= movementUpgradeCost && movementLevel < movementMaxLevel);
    }

    public bool CanCureUpgrade()
    {
        return (points >= cureUpgradeCost && cureLevel < cureMaxLevel);
    }

    public bool CanArmorUpgrade()
    {
        return (points >= armorUpgradeCost && armorLevel < armorMaxLevel);
    }



    public void HealthLevelUpgrade()
    {
        if (CanHealthUpgrade()) 
        {
            if (healthLevel == 0) 
            {
                hero.healthMax += 10;
            }
            if (healthLevel == 1)
            {
                hero.healthMax += 10;
                hero.healthRegeneration += (float)0.2;
            }
            if (healthLevel == 2)
            {
                hero.healthMax += 20;
                hero.healthRegeneration += (float)0.2;
            }
            if (healthLevel == 3)
            {
                hero.healthMax += 20;
                hero.healthRegeneration += (float)0.2;
            }
            if (healthLevel == 4)
            {
                hero.healthMax += 40;
                hero.healthRegeneration += (float)0.3;
            }

            healthLevel++;
            points -= healthUpgradeCost;
            healthUpgradeCost += 9;
        }
    }


    public void EnergyLevelUpgrade()
    {
        if (CanEnergyUpgrade())
        {
            if (energyLevel == 0)
            {
                hero.energyMax += 10;
            }
            if (energyLevel == 1)
            {
                hero.energyMax += 10;
                hero.energyRegeneration += (float)0.2;
            }
            if (energyLevel == 2)
            {
                hero.energyMax += 20;
                hero.energyRegeneration += (float)0.2;
            }
            if (energyLevel == 3)
            {
                hero.energyMax += 20;
                hero.energyRegeneration += (float)0.2;
            }
            if (energyLevel == 4)
            {
                hero.energyMax += 40;
                hero.energyRegeneration += (float)0.3;
            }

            energyLevel++;
            points -= energyUpgradeCost;
            energyUpgradeCost += 9;
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
                skills.sprintPower += 0.5f;
                hero.speed += 0.4f;
            }
            if (movementLevel == 4)
            {
                skills.sprintEnergy -= 1;
                skills.sprintPower += 0.5f;
                hero.speed += 0.6f;
            }

            movementLevel++;
            points -= movementUpgradeCost;
            movementUpgradeCost += 9;
        }
    }

    public void CureLevellUpgrade()
    {
        if (CanCureUpgrade())
        {
            if (cureLevel == 0)
            {
                skills.cureEnergy -= 4;
            }
            if (cureLevel == 1)
            {
                skills.cureEnergy -= 4;
                skills.curePower += 4;
            }
            if (cureLevel == 2)
            {
                skills.cureEnergy -= 4;
                skills.curePower += 4;
            }
            if (cureLevel == 3)
            {
                skills.cureEnergy -= 4;
                skills.curePower += 4;
                skills.cureDelay -= 0.5f;
            }
            if (cureLevel == 4)
            {
                skills.cureEnergy -= 4;
                skills.curePower += 8;
                skills.cureDelay -= 0.5f;
            }

            cureLevel++;
            points -= cureUpgradeCost;
            cureUpgradeCost += 9;
        }
    }

    public void ArmorLevellUpgrade()
    {
        if (CanArmorUpgrade())
        {
            if (armorLevel == 0)
            {
                skills.defenseEnergy -= 0.4f;
            }
            if (armorLevel == 1)
            {
                skills.defenseEnergy -= 0.4f;
                skills.defensePower += 0.5f;
            }
            if (armorLevel == 2)
            {
                skills.defenseEnergy -= 0.4f;
                skills.defensePower += 0.5f;
            }
            if (armorLevel == 3)
            {
                skills.defenseEnergy -= 0.4f;
                hero.armor += 0.5f;
            }
            if (armorLevel == 4)
            {
                skills.defenseEnergy -= 0.4f;
                hero.armor += 0.5f;
            }

            armorLevel++;
            points -= armorUpgradeCost;
            armorUpgradeCost += 9;
        }
    }


}
