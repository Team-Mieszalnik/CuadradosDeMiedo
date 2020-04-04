using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    //private Canvas hudCanvas;
    //private Canvas escapeCanvas;


    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject deathScreen;


    // Start is called before the first frame update
    void Start()
    {

    }



    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Escape)) 
    //        ChangeExitMenuState();
    //    else 
    //        ContinueGame();
    //}

    //public void ChangeExitMenuState()
    //{
    //    escapeCanvas.enabled = !escapeCanvas.enabled;   //turn on escape menu canvas
    //    hudCanvas.enabled = !hudCanvas.enabled;   //turn off escape hud canvas
    //    if (Time.timeScale > 0)
    //        Time.timeScale = 0;         //Stop the game
    //    else Time.timeScale = 1;        //Start the game
    //}

    //public void ContinueGame()
    //{
    //    escapeCanvas.enabled = false;   //turn off escape menu canvas
    //    hudCanvas.enabled = true;   //turn on hud canvas
    //    if (!hudIsInitialized) initializeHUD();
    //    Time.timeScale = 1;        //Start the game
    //    heroHealthText.text = ((int)hero.health).ToString();
    //    heroEnergyDisplay.text = ((int)hero.energy).ToString();
    //    heroHealthBar.value = hero.health;
    //    heroEnergyBar.value = hero.energy;
    //}

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            PauseMenu();


        if (Input.GetKeyUp(KeyCode.U))
            DeathScreen();

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
