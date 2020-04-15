using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UserInterface : MonoBehaviour
{
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject deathScreen;
    public GameObject musicManagerInterface;

    public AudioMixer audioMixer;

    private delegate void ChangeMenuState();
    private ChangeMenuState changeMenuState;

    // Start is called before the first frame update
    void Start()
    {
        changeMenuState = PauseMenu;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            changeMenuState();
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        musicManagerInterface.SetActive(true);
        Time.timeScale = 0;
        changeMenuState = ContinueGame;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        musicManagerInterface.SetActive(false);
        Time.timeScale = 1;
        changeMenuState = PauseMenu;
    }

    public void DeathScreen()
    {
        changeMenuState = null;
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", 20 * Mathf.Log10(volume));
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", 20 * Mathf.Log10(volume));
    }

    public void SetEffects(float volume)
    {
        audioMixer.SetFloat("SoundEffects", 20 * Mathf.Log10(volume));
    }

}
