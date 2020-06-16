using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/**
 * @brief Singleton zarządzający muzyką na mapach oraz w menu
 */
public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private AudioSource audioSource;

    //Order of songs:
    // 1 Square it up
    // 2 Hex bells
    public AudioClip audioClip_MainMenu;
    public AudioClip audioClip_Death;
    public AudioClip[] audioClips_Primavera;
    public AudioClip[] audioClips_Invierno;
    public AudioClip[] audioClips_Arena;
    public AudioClip[] audioClips_Vesuvio;
    public AudioClip[] audioClips_Cueva;
    private string currentMapName;
    /**
     * number of levels completed by player
     */
    private int bigLevel;

    private bool isPlaying = true;

    /**
     * @brief Sets next music track and stops the music
     * Called only on LoadingScreen
     * @param newMapName name of map to be loaded
     */
    public void LoadingScreen(string newMapName = "UNDEFINED")
    {
        currentMapName = newMapName;
        StopMusic();
    }

    /**
     * @brief Starts music on map
     */
    public static void StartMap() => Instance.PlayMusic();

    /**
     * @brief Initializes all parameters, sets music to MainMenu
     */
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        if (_instance == null) _instance = this;
        else return;
        bigLevel = 0;
        PlayMusic("MainMenu");
        DontDestroyOnLoad(gameObject);
    }

    /**
     * @brief Starts or stops music - called from MusicManagerInterface
     */
    public void StartStopFunction()
    {
        Text buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        if (isPlaying)
        {
            PauseMusic();
            buttonText.text = "Start Music";
        }
        else
        {
            PlayMusic();
            buttonText.text = "Stop Music";
        }
    }

    private void PauseMusic()
    {
        isPlaying = false;
        //StopCoroutine("WaitForMusicEnd");
        //audioSource.Stop();
        audioSource.Pause();
    }

    private void StopMusic()
    {
        isPlaying = false;
        //StopCoroutine("WaitForMusicEnd");
        audioSource.Stop();
    }

    public static void PlayMusic(string map)
    {
        Instance.currentMapName = map;
        Instance.PlayMusic();
    }

    /**
     * @brief called by static PlayMusic, plays music depending on current map
     */
    private void PlayMusic()
    {
        isPlaying = true;
        //audioSource.Stop();
        audioSource.Pause();
        switch (currentMapName)
        {
            case "MainMenu":
                audioSource.clip = audioClip_MainMenu;
                bigLevel = 0;
                break;
            case "Death":
                audioSource.clip = audioClip_Death;
                bigLevel = 0;
                break;

            case "Primavera":
                audioSource.clip = audioClips_Primavera[bigLevel];
                break;
            case "Invierno":
                audioSource.clip = audioClips_Invierno[bigLevel];
                break;
            case "Arena":
                audioSource.clip = audioClips_Arena[bigLevel];
                break;
            case "Vesuvio":
                audioSource.clip = audioClips_Vesuvio[bigLevel];
                break;
            case "Boss":
                audioSource.clip = audioClips_Primavera[bigLevel];
                bigLevel++;
                break;
            case "Cueva":
                audioSource.clip = audioClips_Cueva[bigLevel];
                bigLevel++;
                break;
            default:
                audioSource.clip = audioClips_Primavera[bigLevel];
                break;
        }
        audioSource.Play();
    }
    public void NextClip()
    {
        if (++bigLevel > audioClips_Primavera.Length - 1) bigLevel = 0;
        if (isPlaying) PlayMusic();
    }
    public void PreviousClip()
    {
        if (--bigLevel < 0) bigLevel = audioClips_Primavera.Length - 1;
        if (isPlaying) PlayMusic();
    }
}
