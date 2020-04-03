using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    //public Canvas hudCanvas;
    //public Canvas escapeCanvas;
    private Canvas hudCanvas;
    private Canvas escapeCanvas;
    //public GameObject playSpace;
    private Text heroHealthText;
    private Text heroEnergyDisplay;
    private Hero hero;
    private Slider heroHealthBar;
    private Slider heroEnergyBar;
    private bool hudIsInitialized = false;

    // Start is called before the first frame update
    void Start()
    {

        //Initialize key components

        hudCanvas = GameObject.Find("HUD").GetComponent<Canvas>();
        escapeCanvas = GameObject.Find("EscapeMenu").GetComponent<Canvas>();
        heroHealthText = GameObject.Find("HeroHealthDisplay").GetComponent<Text>();
        heroEnergyDisplay = GameObject.Find("HeroEnergyDisplay").GetComponent<Text>();
        heroHealthBar = GameObject.Find("HeroHealthBar").GetComponent<Slider>();
        heroEnergyBar = GameObject.Find("HeroEnergyBar").GetComponent<Slider>();
        initializeHUD();
        //  //

        // Starting state of the scene
        escapeCanvas.enabled = false; //turn off escape menu canvas
        hudCanvas.enabled = true;   //turn on hud canvas
        //Time.timeScale = 0;         //Stop the game
    }

    private void initializeHUD()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        heroHealthBar.maxValue = hero.healthMax;
        heroEnergyBar.maxValue = hero.energyMax;
        hudIsInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) ChangeExitMenuState();
        else ContinueGame();
    }

    public void ChangeExitMenuState()
    {
        escapeCanvas.enabled = !escapeCanvas.enabled;   //turn on escape menu canvas
        hudCanvas.enabled = !hudCanvas.enabled;   //turn off escape hud canvas
        if (Time.timeScale > 0)
            Time.timeScale = 0;         //Stop the game
        else Time.timeScale = 1;        //Start the game
    }

    public void ContinueGame()
    {
        escapeCanvas.enabled = false;   //turn off escape menu canvas
        hudCanvas.enabled = true;   //turn on hud canvas
        if (!hudIsInitialized) initializeHUD();
        Time.timeScale = 1;        //Start the game
        heroHealthText.text = ((int)hero.health).ToString();
        heroEnergyDisplay.text = ((int)hero.energy).ToString();
        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
    }

}
