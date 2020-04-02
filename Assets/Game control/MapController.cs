using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public static void EndLevel()
    {
        if (LevelController.LevelCompleted())
        {
            CreateLoadingScene();
        }
    }


    public static void GoNextLevel()
    {
        CreateScene();
    }




    public static void CreateFirstLevel()
    {
        LevelController.ResetLevel();

        SceneSetings();

        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }



    protected static void CreateScene()
    {
        SceneSetings();


        GameObject.Find("Hero").transform.parent = null;
        DontDestroyOnLoad(GameObject.Find("Hero"));

        //AsyncOperation loadScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(GameObject.Find("Hero"), SceneManager.GetSceneByName(SceneName));
    }

    protected static void CreateLoadingScene()
    {
        GameObject.Find("Hero").transform.parent = null;
        DontDestroyOnLoad(GameObject.Find("Hero"));

        SceneManager.LoadScene("LoadingLevel", LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(GameObject.Find("Hero"), SceneManager.GetSceneByName("LoadingLevel"));
    }





    protected static void SceneSetings()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                SceneName = "Arena1";
                break;
            case 2:
                SceneName = "Arena2";
                break;
            default:
                SceneName = "Arena2";
                break;
        }
    }
}
