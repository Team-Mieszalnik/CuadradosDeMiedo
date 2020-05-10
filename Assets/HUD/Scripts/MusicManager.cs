using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    //Singleton
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
    public AudioClip[] audioClips_Primavera;    //map 1
    public AudioClip[] audioClips_Invierno;    //map 2
    public AudioClip[] audioClips_Arena;
    public AudioClip[] audioClips_Vesuvio;

    private int bigLevel;

    private bool isPlaying = true;

    private string currentMapName;
    public void LoadingScreen(string newMapName = "UNDEFINED")
    {
        currentMapName = newMapName;
        StopMusic();
    }
    public static void StartMap() => Instance.PlayMusic();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (_instance == null) _instance = this;
        else return;
        bigLevel = 0;
        PlayMusic();
        DontDestroyOnLoad(gameObject);
    }

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

    private void PlayMusic()
    {
        isPlaying = true;
        //audioSource.Stop();
        audioSource.Pause();
        switch (currentMapName)
        {
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
            default:
                audioSource.clip = audioClips_Primavera[bigLevel];
                break;
        }
        audioSource.Play();
        //StartCoroutine("WaitForMusicEnd");
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

    //IEnumerator WaitForMusicEnd()
    //{
    //    while (audioSource.isPlaying) yield return null;
    //    NextClip();
    //}
}
