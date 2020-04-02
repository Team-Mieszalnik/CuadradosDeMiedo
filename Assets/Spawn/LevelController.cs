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
    //protected List<GameObject> spawnPointsObstacle;

    public GameObject hero;

    public List<GameObject> enemies;
    [HideInInspector] public List<int> enemiesCounter;

    //public List<GameObject> obstacles;
    //[HideInInspector] public List<int> obstaclesCounter;


    // Start is called before the first frame update
    void Start()
    {
        enemiesCounter = new List<int>(Enumerable.Repeat<int>(0, enemies.Count));
        enemyCounter = 0;

        //spawnPointsObstacle = new List<GameObject>();
        spawnPointsEnemy = new List<GameObject>();
        spawnPointsHero = new List<GameObject>();

        //spawnPointsObstacle.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointObstacle"));
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
                enemiesCounter[0] = 0;//circleEnemyCount
                enemiesCounter[1] = 1;//triangleEnemyCount
                enemiesCounter[2] = 0;//squareEnemyCount
                break;
            case 2:
                enemiesCounter[0] = 1;//circleEnemyCount
                enemiesCounter[1] = 1;//triangleEnemyCount
                enemiesCounter[2] = 0;//squareEnemyCount
                break;
            case 3:
                enemiesCounter[0] = 1;//circleEnemyCount
                enemiesCounter[1] = 1;//triangleEnemyCount
                enemiesCounter[2] = 1;//squareEnemyCount
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

        for (int i = 0; i < enemies.Count; i++) 
        {
            Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
            Debug.Log("first for: enemies.count: " + enemies.Count);
            for (int j = 0; j < enemiesCounter[i]; j++) 
            {
                Debug.Log("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
                Debug.Log("second for: enemiesCounter: " + enemiesCounter[i]);
                positionNumber = Random.Range(0, spawnPointsEnemy.Count - 1);
                Instantiate(enemies[i], spawnPointsEnemy[positionNumber].transform);

                spawnPointsEnemy.RemoveAt(positionNumber);
            }
        }

    }
}