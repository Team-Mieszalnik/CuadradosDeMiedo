using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager
{

    public static float BestTime
    {
        get => PlayerPrefs.GetFloat("BestTime", 0);
        set
        {
            float prevBestTime = PlayerPrefs.GetFloat("BestTime", 0);

            if (value < prevBestTime)
                PlayerPrefs.SetFloat("BestTime", value);
        }
    }

    public static int HighestLevel
    {
        get => PlayerPrefs.GetInt("HighestLevel", 0);
        set
        {
            int prevBestLevel = PlayerPrefs.GetInt("HighestLevel", 0);

            if (value > prevBestLevel)
                PlayerPrefs.SetInt("HighestLevel", value);
        }
    }

    public static int EnemiesKilled
    {
        get => PlayerPrefs.GetInt("EnemiesKilled", 0);
        set
        {
            int prevKills = PlayerPrefs.GetInt("EnemiesKilled", 0);
            prevKills += value;
            PlayerPrefs.SetInt("EnemiesKilled", prevKills);
        }
    }

}
