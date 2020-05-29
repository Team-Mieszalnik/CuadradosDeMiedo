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
    public GameObject mapPreview;

    public AudioMixer audioMixer;

    private delegate void ChangeMenuState();
    private ChangeMenuState changeMenuState;
    private ChangeMenuState changeMapState;

    // Start is called before the first frame update
    void Start()
    {
        changeMenuState = PauseMenu;
        changeMapState = MapPreview;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            changeMenuState();

        if (Input.GetKeyDown(KeyCode.Tab))
            changeMapState();

    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        mapPreview.SetActive(false);
        Time.timeScale = 0;
        changeMenuState = ContinueGame;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        mapPreview.SetActive(false);
        Time.timeScale = 1;
        changeMenuState = PauseMenu;
        changeMapState = MapPreview;
    }

    public void DeathScreen()
    {
        changeMenuState = null;
        changeMapState = null;
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

    public void MapPreview()
    {
        mapPreview.SetActive(true);
        Time.timeScale = 0;
        changeMapState = ContinueGame;
    }


    public void SetGlobalVolume(float volume)
    {
        audioMixer.SetFloat("Volume", 20 * Mathf.Log10(volume));
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", 20 * Mathf.Log10(volume));
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffects", 20 * Mathf.Log10(volume));
    }

}
