using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public Canvas hudCanvas;
    public Canvas escapeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        hudCanvas = hudCanvas.GetComponent<Canvas>();
        escapeCanvas = escapeCanvas.GetComponent<Canvas>();

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
