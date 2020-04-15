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






    protected void SpawnSettings()
    {
        switch (Level)
        {
            case 1:
                AddEnemiesWave();
                enemiesCounter[0][0] = 1;//c1
                enemiesCounter[0][1] = 2;//t1
                enemiesCounter[0][2] = 1;//s1

                AddEnemiesWave();
                enemiesCounter[1][0] = 1;//c1
                enemiesCounter[1][1] = 2;//t1
                enemiesCounter[1][2] = 1;//s1

                enemiesToNextWave = 0;


                obstaclesCounter[0] = 40;//rock
                obstaclesCounter[1] = 0;//tree
                obstaclesCounter[2] = 1;//tower
                break;
            case 2:
                AddEnemiesWave();
                enemiesCounter[0][0] = 1;//c1
                enemiesCounter[0][1] = 2;//t1
                enemiesCounter[0][2] = 1;//s1

                AddEnemiesWave();
                enemiesCounter[1][0] = 2;//c1
                enemiesCounter[1][1] = 1;//t1
                enemiesCounter[1][2] = 1;//s1

                enemiesToNextWave = 2;


                obstaclesCounter[0] = 70;//rock
                obstaclesCounter[1] = 0;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 3:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//c1
                enemiesCounter[0][1] = 1;//t1
                enemiesCounter[0][2] = 2;//s1

                AddEnemiesWave();
                enemiesCounter[1][0] = 2;//c1
                enemiesCounter[1][1] = 2;//t1
                enemiesCounter[1][2] = 1;//s1

                AddEnemiesWave();
                enemiesCounter[2][0] = 1;//c1
                enemiesCounter[2][1] = 2;//t1
                enemiesCounter[2][2] = 2;//s1

                enemiesToNextWave = 4;


                obstaclesCounter[0] = 10;//rock
                obstaclesCounter[1] = 30;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 4:
                AddEnemiesWave();
                enemiesCounter[0][0] = 5;//c1

                AddEnemiesWave();
                enemiesCounter[1][1] = 5;//t1

                AddEnemiesWave();
                enemiesCounter[2][2] = 5;//s1

                enemiesToNextWave = 2;


                obstaclesCounter[0] = 20;//rock
                obstaclesCounter[1] = 40;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 5://BOSS
                AddEnemiesWave();
                enemiesCounter[0][9] = 1;//bc1

                obstaclesCounter[0] = 20;//rock
                break;
            case 6:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//c1
                enemiesCounter[0][1] = 2;//t1
                enemiesCounter[0][5] = 1;//s2

                AddEnemiesWave();
                enemiesCounter[1][0] = 2;//c1
                enemiesCounter[1][4] = 1;//t2
                enemiesCounter[1][2] = 2;//s1

                AddEnemiesWave();
                enemiesCounter[2][3] = 2;//c2
                enemiesCounter[2][1] = 1;//t1
                enemiesCounter[2][2] = 2;//s1

                enemiesToNextWave = 0;


                obstaclesCounter[0] = 40;//rock
                obstaclesCounter[1] = 30;//tree
                obstaclesCounter[2] = 3;//tower
                break;

            case 7:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//c1
                enemiesCounter[0][4] = 2;//t2
                enemiesCounter[0][5] = 1;//s2

                AddEnemiesWave();
                enemiesCounter[1][3] = 2;//c2
                enemiesCounter[1][4] = 2;//t2
                enemiesCounter[1][5] = 2;//s2

                AddEnemiesWave();
                enemiesCounter[2][3] = 2;//c2
                enemiesCounter[2][4] = 2;//t2
                enemiesCounter[2][5] = 2;//s2

                enemiesToNextWave = 2;


                obstaclesCounter[0] = 100;//rock
                obstaclesCounter[1] = 10;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 8:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//c1
                enemiesCounter[0][1] = 2;//t1
                enemiesCounter[0][2] = 2;//s1
                enemiesCounter[0][3] = 1;//c2
                enemiesCounter[0][4] = 1;//t2
                enemiesCounter[0][5] = 1;//s2

                AddEnemiesWave();
                enemiesCounter[1][0] = 2;//c1
                enemiesCounter[1][1] = 2;//t1
                enemiesCounter[1][2] = 2;//s1
                enemiesCounter[1][3] = 2;//c2
                enemiesCounter[1][4] = 2;//t2
                enemiesCounter[1][5] = 2;//s2

                enemiesToNextWave = 0;


                obstaclesCounter[0] = 100;//rock
                obstaclesCounter[1] = 40;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 9:
                AddEnemiesWave();
                enemiesCounter[0][3] = 5;//c2

                AddEnemiesWave();
                enemiesCounter[1][4] = 5;//t2

                AddEnemiesWave();
                enemiesCounter[1][5] = 5;//s2

                enemiesToNextWave = 1;


                obstaclesCounter[0] = 20;//rock
                obstaclesCounter[1] = 8;//tree
                obstaclesCounter[2] = 1;//tower
                break;
            case 10://BOSS
                AddEnemiesWave();
                enemiesCounter[0][10] = 1;//bt1

                obstaclesCounter[0] = 10;//rock
                obstaclesCounter[1] = 3;//tree
                break;
            case 11:
                AddEnemiesWave();
                enemiesCounter[0][6] = 2;//c3
                enemiesCounter[0][1] = 1;//t1
                enemiesCounter[0][2] = 2;//s1
                enemiesCounter[0][3] = 1;//c2
                enemiesCounter[0][4] = 1;//t2
                enemiesCounter[0][5] = 1;//s2

                AddEnemiesWave();
                enemiesCounter[1][0] = 2;//c1
                enemiesCounter[1][7] = 1;//t3
                enemiesCounter[1][2] = 2;//s1
                enemiesCounter[1][3] = 1;//c2
                enemiesCounter[1][4] = 1;//t2
                enemiesCounter[1][5] = 1;//s22

                AddEnemiesWave();
                enemiesCounter[2][0] = 2;//c1
                enemiesCounter[2][1] = 2;//t1
                enemiesCounter[2][8] = 1;//s3
                enemiesCounter[2][3] = 1;//c2
                enemiesCounter[2][4] = 1;//t2
                enemiesCounter[2][5] = 1;//s2

                enemiesToNextWave = 0;


                obstaclesCounter[0] = 20;//rock
                obstaclesCounter[1] = 10;//tree
                obstaclesCounter[2] = 1;//tower
                break;
            case 12:
                AddEnemiesWave();
                enemiesCounter[0][6] = 2;//c3
                enemiesCounter[0][7] = 2;//t3
                enemiesCounter[0][8] = 2;//s3

                AddEnemiesWave();
                enemiesCounter[1][6] = 2;//c3
                enemiesCounter[1][7] = 2;//t3
                enemiesCounter[1][8] = 2;//s3

                AddEnemiesWave();
                enemiesCounter[2][6] = 2;//c3
                enemiesCounter[2][7] = 2;//t3
                enemiesCounter[2][8] = 2;//s3

                enemiesToNextWave = 3;


                obstaclesCounter[0] = 200;//rock
                obstaclesCounter[1] = 0;//tree
                obstaclesCounter[2] = 0;//tower
                break;
            case 13:
                AddEnemiesWave();
                enemiesCounter[0][0] = 2;//c1
                enemiesCounter[0][3] = 2;//c2
                enemiesCounter[0][6] = 3;//c3

                AddEnemiesWave();
                enemiesCounter[1][1] = 2;//t1
                enemiesCounter[1][3] = 2;//t2
                enemiesCounter[1][7] = 3;//t3

                AddEnemiesWave();
                enemiesCounter[1][2] = 2;//s1
                enemiesCounter[1][5] = 2;//s2
                enemiesCounter[1][8] = 3;//s3

                enemiesToNextWave = 1;


                obstaclesCounter[0] = 20;//rock
                obstaclesCounter[1] = 10;//tree
                obstaclesCounter[2] = 1;//tower
                break;

            case 14:
                AddEnemiesWave();
                enemiesCounter[0][3] = 2;//c2
                enemiesCounter[0][4] = 2;//t2
                enemiesCounter[0][5] = 2;//s2
                enemiesCounter[0][6] = 1;//c3
                enemiesCounter[0][7] = 1;//t3
                enemiesCounter[0][8] = 1;//s3

                AddEnemiesWave();
                enemiesCounter[0][3] = 1;//c2
                enemiesCounter[0][4] = 1;//t2
                enemiesCounter[0][5] = 1;//s2
                enemiesCounter[0][6] = 2;//c3
                enemiesCounter[0][7] = 2;//t3
                enemiesCounter[0][8] = 2;//s3

                AddEnemiesWave();
                enemiesCounter[1][6] = 3;//c3
                enemiesCounter[1][7] = 3;//t3
                enemiesCounter[1][8] = 3;//s3

                enemiesToNextWave = 1;


                obstaclesCounter[0] = 30;//rock
                obstaclesCounter[1] = 10;//tree
                obstaclesCounter[2] = 2;//tower
                break;
            case 15://BOSS
                AddEnemiesWave();
                enemiesCounter[0][11] = 1;//bs1

                obstaclesCounter[0] = 10;//rock
                obstaclesCounter[1] = 4;//tree
                break;
            default:
                break;
        }

        foreach (List<int> wave in enemiesCounter)
        {
            foreach (int count in wave)
            {
                enemyCounter += count;
            }
        }
    }
}