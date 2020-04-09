using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int Level { get; private set; }


    public static int enemyCounter;
    public static int enemyCounterWave;
    protected int enemiesToNextWave;
    protected int waveNumber;



    protected List<GameObject> spawnPointsEnemy;
    protected List<GameObject> spawnPointsHero;
    protected List<GameObject> spawnPointsObstacle;

    public GameObject hero;

    public List<GameObject> enemies;
    [HideInInspector] public List<List<int>> enemiesCounter;

    public List<GameObject> obstacles;
    [HideInInspector] public List<int> obstaclesCounter;


    // Start is called before the first frame update
    void Start()
    {
        enemiesCounter = new List<List<int>>();
        enemyCounter = 0;
        enemyCounterWave = 0;
        enemiesToNextWave = 0;
        waveNumber = 0;

        obstaclesCounter = new List<int>();
        obstaclesCounter.AddRange(Enumerable.Repeat<int>(0, obstacles.Count));


        spawnPointsObstacle = new List<GameObject>();
        spawnPointsEnemy = new List<GameObject>();
        spawnPointsHero = new List<GameObject>();

        spawnPointsObstacle.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointObstacle"));
        spawnPointsEnemy.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointEnemy"));
        spawnPointsHero.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointHero"));


        SpawnSettings();

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        WaveController();
    }



    public static bool LevelCompleted()
    {
        if (enemyCounter <= 0)
        {
            Level++;
            return true;
        }

        return false;
    }

    public static void ResetLevel()
    {
        Level = 1;
    }


    protected void SpawnSettings()
    {
        switch (Level)
        {
            case 1:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//circle1

                AddEnemiesWave();
                enemiesCounter[1][1] = 1;//triangle1

                enemiesToNextWave = 1;

                obstaclesCounter[0] = 20;//rock
                obstaclesCounter[1] = 5;//tree
                obstaclesCounter[2] = 2;//tower
                break;
            case 2:
                AddEnemiesWave();
                enemiesCounter[0][0] = 8;//circle1
                enemiesCounter[0][1] = 8;//triangle1
                enemiesCounter[0][2] = 8;//square1
                enemiesCounter[0][3] = 8;//circle2
                enemiesCounter[0][4] = 8;//triangle2
                enemiesCounter[0][5] = 8;//square2
                enemiesCounter[0][6] = 8;//circle3
                enemiesCounter[0][7] = 8;//triangle3
                enemiesCounter[0][8] = 8;//square3

                obstaclesCounter[0] = 200;//rock
                break;
            case 3:
                AddEnemiesWave();
                enemiesCounter[0][0] = 5;//circleEnemyCount
                enemiesCounter[0][1] = 10;//triangleEnemyCount
                enemiesCounter[0][2] = 5;//squareEnemyCount
                break;
            default:
                break;
        }

        foreach(List<int> wave in enemiesCounter)
        {
            foreach (int count in wave) 
            {
                enemyCounter += count;
            }
        }
    }


    protected void Spawn()
    {
        SpawnHero();

        SpawnEnemy(0);

        SpawnObstacles();
    }

    protected void SpawnHero()
    {
        if (spawnPointsHero.Count <= 0)//check the availability of spawn points
        {
            Debug.Log("MISSED SPAWN POINTS - HERO");
            return;
        }

        int positionNumber;
        positionNumber = Random.Range(0, spawnPointsHero.Count - 1);

        if (GameObject.Find("Hero") != null)
        {
            GameObject.Find("Hero").transform.position = spawnPointsHero[positionNumber].transform.position;
        }
        else
        {
            Instantiate(hero, spawnPointsHero[positionNumber].transform).name = "Hero";
        }
    }

    protected void SpawnEnemy(int wave)
    {
        List<int> enemiesWave = enemiesCounter[wave];

        int positionNumber;

        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 0; j < enemiesWave[i]; j++)
            {
                if (spawnPointsEnemy.Count <= 0)//check the availability of spawn points
                {
                    Debug.Log("MISSED SPAWN POINTS - ENEMY");
                    return;
                }


                positionNumber = Random.Range(0, spawnPointsEnemy.Count - 1);
                Instantiate(enemies[i], spawnPointsEnemy[positionNumber].transform);

                spawnPointsEnemy.RemoveAt(positionNumber);
                enemyCounterWave++;
            }
        }
    }

    protected void SpawnObstacles()
    {
        int positionNumber;

        for (int i = 0; i < obstacles.Count; i++)
        {
            for (int j = 0; j < obstaclesCounter[i]; j++)
            {
                if (spawnPointsObstacle.Count <= 0)//check the availability of spawn points
                {
                    Debug.Log("MISSED SPAWN POINTS - OBSTACLE");
                    return;
                }


                positionNumber = Random.Range(0, spawnPointsObstacle.Count - 1);
                Instantiate(obstacles[i], spawnPointsObstacle[positionNumber].transform);

                spawnPointsObstacle.RemoveAt(positionNumber);
            }
        }
    }



    protected void AddEnemiesWave()
    {
        enemiesCounter.Add(new List<int>());
        enemiesCounter[enemiesCounter.Count - 1].AddRange(Enumerable.Repeat<int>(0, enemies.Count));
    }

    protected void WaveController()
    {
        if (enemiesToNextWave >= enemyCounterWave) 
        {
            waveNumber++;

            if (enemiesCounter[waveNumber] != null) 
            {
                SpawnEnemy(waveNumber);
            }
        }
    }


    public static void DecrementEnemyCounter()
    {
        enemyCounter--;
        enemyCounterWave--;
    }
}