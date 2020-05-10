using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticMenu : MonoBehaviour
{

    public TextMeshProUGUI highestLevel;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        highestLevel.text = StatsManager.HighestLevel.ToString();
        bestTime.text = StatsManager.BestTime.ToString();
        enemiesKilled.text = StatsManager.EnemiesKilled.ToString();
    }

}
