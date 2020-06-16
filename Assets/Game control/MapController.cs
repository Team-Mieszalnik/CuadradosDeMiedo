using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
         * @brief
         * Kontroler do zarzadzania mapami 
         */
public class MapController : MonoBehaviour
{
    public static string SceneName { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        //if (SceneManager.GetActiveScene().name.Equals(SceneName))
        //{
        //    SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        //}
        //else
        //{
        //    SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(0));
        //}
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    // Update is called once per frame
    void Update()
    {

    }


    /**
         * @brief
         * Metoda do zakonczenia poziomu 
         */
    public static void EndLevel()
    {
        if (LevelController.LevelCompleted())
        {
            CreateLoadingScene();
        }
    }


    /**
         * @brief
         * Metoda do tworzenia nowego poziomu 
         */
    public static void GoNextLevel()
    {
        CreateScene();
    }



    /**
         * @brief
         * Metoda do tworzenia pierwszego poziomu 
         */
    public static void CreateFirstLevel()
    {
        LevelController.ResetLevel();

        CreateLoadingScene();
    }



    /**
         * @brief
         * Metoda tworzaca scene z danym poziomem 
         */
    protected static void CreateScene()
    {
        if (GameObject.Find("Hero") != null)
        {
            GameObject.Find("Hero").transform.parent = null;
            DontDestroyOnLoad(GameObject.Find("Hero"));
        }

        //AsyncOperation loadScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(GameObject.Find("Hero"), SceneManager.GetSceneByName(SceneName));
    }

    /**
         * @brief
         * Metoda tworzaca scene ladowania 
         */
    protected static void CreateLoadingScene()
    {
        SceneSetings();

        MusicManager.Instance.LoadingScreen(SceneName);

        if (GameObject.Find("Hero") != null)
        {
            GameObject.Find("Hero").transform.parent = null;
            DontDestroyOnLoad(GameObject.Find("Hero"));
        }

        SceneManager.LoadScene("LoadingLevel", LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(GameObject.Find("Hero"), SceneManager.GetSceneByName("LoadingLevel"));
    }




    /**
         * @brief
         * Metoda wczytujaca ustawienia nastepnej mapy
         */
    protected static void SceneSetings()
    {
        if (LevelController.Level == 16)
        {
            SceneName = "Credits";
            return;
        }

        if (LevelController.Level % 5 != 0)
        {
            switch (Random.Range(1, 6))
            {
                case 1:
                    SceneName = "Arena";
                    break;
                case 2:
                    SceneName = "Invierno";
                    break;
                case 3:
                    SceneName = "Primavera";
                    break;
                case 4:
                    SceneName = "Vesuvio";
                    break;
                case 5:
                    SceneName = "Cueva";
                    break;
                default:
                    SceneName = "Arena";
                    break;
            }
        }
        else
        {
            SceneName = "Boss";
        }
    }
}
