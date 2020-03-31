﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    //public Canvas hudCanvas;
    //public Canvas escapeCanvas;
    private Canvas hudCanvas;
    private Canvas escapeCanvas;
    public GameObject playSpace;
    private Text heroHealthText;
    private Hero hero;

    // Start is called before the first frame update
    void Start()
    {

        //Initialize key components

        foreach (var child in transform.GetComponentsInChildren<Canvas>())
        {
            if (child.name == "HUD") hudCanvas = child;
            else if (child.name == "EscapeMenu") escapeCanvas = child;
        }
        //hudCanvas = hudCanvas.GetComponent<Canvas>();
        //escapeCanvas = escapeCanvas.GetComponent<Canvas>();


        hero = playSpace.GetComponentInChildren<Hero>();
        //hero = hero.GetComponent<Hero>();
        //heroHealthText = GameObject.Find("UserInterface/HUD/HeroHealthDisplay").GetComponent<Text>();
        foreach (var child in hudCanvas.GetComponentsInChildren<Text>())
        {
            if (child.name == "HeroHealthDisplay") heroHealthText = child;
        }
        //heroHealthText = ;

        //  //

        // Starting state of the scene
        escapeCanvas.enabled = true; //turn on escape menu canvas
        hudCanvas.enabled = false;   //turn off hud canvas
        Time.timeScale = 0;         //Stop the game
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ChangeExitMenuState();
        }
        heroHealthText.text = hero.health.ToString();
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
        hudCanvas.enabled = true;   //turn on escape hud canvas
        Time.timeScale = 1;        //Start the game
    }

}