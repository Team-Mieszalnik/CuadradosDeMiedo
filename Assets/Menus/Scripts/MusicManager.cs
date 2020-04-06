using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static bool isThereAnInstance = false;

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private bool isPlaying = true;
    private int currentClipNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (isThereAnInstance)
        {
            Destroy(gameObject);
            return;
        }
        isThereAnInstance = true;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);              //This makes sure that the music manager stays between the scenes
        currentClipNumber = 0;
        PlayMusic();
    }

    public void StartStopFunction()
    {
        Text buttonText= EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        if (isPlaying)
        { 
            StopMusic();
            buttonText.text = "Start Music";
        }
        else
        {
            PlayMusic();
            buttonText.text = "Stop Music";
        }
    }

    private void StopMusic()
    {
        isPlaying = false;
        StopCoroutine("WaitForMusicEnd");
        audioSource.Stop();
    }

    private void PlayMusic()
    {
        isPlaying = true;
        audioSource.Stop();
        audioSource.clip = audioClips[currentClipNumber];
        audioSource.Play();
        StartCoroutine("WaitForMusicEnd");
    }

    public void NextClip()
    {
        if (++currentClipNumber >= audioClips.Length) currentClipNumber = 0;
        if (isPlaying) PlayMusic();
    }
    public void PreviousClip()
    {
        if (--currentClipNumber < 0) currentClipNumber = audioClips.Length-1;
        if (isPlaying) PlayMusic();
    }

    IEnumerator WaitForMusicEnd()
    {
        while (audioSource.isPlaying) yield return null;
        NextClip();
    }
}
