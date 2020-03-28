using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Experience : MonoBehaviour
{
    public static int defeatedOpponents { get; private set; }

    public static int points;
    private int upgradeCost = 10;


    private int healthLevel;
    private int moveLevel;

    private int healthMaxLevel = 2;
    private int moveMaxLevel = 2;


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
        defeatedOpponents += number;
        points += number;
    }


    void HealthLevelUpgrade()
    {
        if (points - upgradeCost >= 0 && healthLevel > healthMaxLevel) 
        {
            if (healthLevel == 0) 
            {
                hero.health += 10;
            }
            if (healthLevel == 1)
            {
                hero.healthRegeneration += (float)0.1;
            }

            healthLevel++;
            points -= upgradeCost;
        }
    }

    void MoveLevellUpgrade()
    {
        if (points - upgradeCost >= 0 && moveLevel > moveMaxLevel)
        {
            if (moveLevel == 0)
            {
                skills.sprintEnergy -= 3;
            }
            if (moveLevel == 1)
            {
                hero.speed += 1;
            }

            moveLevel++;
            points -= upgradeCost;
        }
    }


}
