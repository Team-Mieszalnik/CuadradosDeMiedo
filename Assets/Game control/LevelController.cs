using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int Level { get; private set; }


    public static int enemyCounter;


    protected List<GameObject> spawnPointsEnemy;
    protected List<GameObject> spawnPointsHero;
    protected List<GameObject> spawnPointsObstacle;

    public GameObject hero;

    public List<GameObject> enemies;
    [HideInInspector] public List<int> enemiesCounter;

    public List<GameObject> obstacles;
    [HideInInspector] public List<int> obstaclesCounter;


    // Start is called before the first frame update
    void Start()
    {
        enemiesCounter = new List<int>();
        enemiesCounter.AddRange(Enumerable.Repeat<int>(0, enemies.Count));
        enemyCounter = 0;

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
                enemiesCounter[0] = 1;//circle1

                obstaclesCounter[0] = 20;//rock
                break;
            case 2:
                enemiesCounter[0] = 8;//circle1
                enemiesCounter[1] = 8;//triangle1
                enemiesCounter[2] = 8;//square1
                enemiesCounter[3] = 8;//circle2
                enemiesCounter[4] = 8;//triangle2
                enemiesCounter[5] = 8;//square2
                enemiesCounter[6] = 8;//circle3
                enemiesCounter[7] = 8;//triangle3
                enemiesCounter[8] = 8;//square3

                obstaclesCounter[0] = 200;//rock
                break;
            case 3:
                enemiesCounter[0] = 5;//circleEnemyCount
                enemiesCounter[1] = 10;//triangleEnemyCount
                enemiesCounter[2] = 5;//squareEnemyCount
                break;
            default:
                break;
        }

        foreach(int count in enemiesCounter)
        {
            enemyCounter += count;
        }
    }


    protected void Spawn()
    {
        SpawnHero();

        SpawnEnemy();

        SpawnObstacles();
    }

    protected void SpawnHero()
    {
        if (spawnPointsHero.Count <= 0)//check the availability of spawn points
        {
            Debug.Log("MISSED SPAWN POINTS - HERO");
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

    protected void SpawnEnemy()
    {
        int positionNumber;

        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 0; j < enemiesCounter[i]; j++)
            {
                if (spawnPointsEnemy.Count <= 0)//check the availability of spawn points
                {
                    Debug.Log("MISSED SPAWN POINTS - ENEMY");
                }


                positionNumber = Random.Range(0, spawnPointsEnemy.Count - 1);
                Instantiate(enemies[i], spawnPointsEnemy[positionNumber].transform);

                spawnPointsEnemy.RemoveAt(positionNumber);
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
                }


                positionNumber = Random.Range(0, spawnPointsObstacle.Count - 1);
                Instantiate(obstacles[i], spawnPointsObstacle[positionNumber].transform);

                spawnPointsObstacle.RemoveAt(positionNumber);
            }
        }
    }
}