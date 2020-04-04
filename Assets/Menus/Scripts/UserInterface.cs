using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject deathScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMenu();
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void DeathScreen()
    {
        deathScreen.SetActive(true);
        //pauseMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        //SceneManager.UnloadScene(SceneManager.GetActiveScene());
    }

}
