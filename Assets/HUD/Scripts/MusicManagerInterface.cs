using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * @brief Klasa zarządzająca graficznym interfejsem muzyki
 * Wysyła komendo do MusicManagerInterface
 */
public class MusicManagerInterface : MonoBehaviour
{
    public Button startStopMusicButton;
    public Button nextClipButton;
    public Button previousClipButton;
    private MusicManager musicManager;

    /**
     * @brief Initializes all buttons and connects them to MusicManager
     */
    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        startStopMusicButton = startStopMusicButton.GetComponent<Button>();
        nextClipButton = nextClipButton.GetComponent<Button>();
        previousClipButton = previousClipButton.GetComponent<Button>();
        startStopMusicButton.onClick.AddListener(musicManager.StartStopFunction);
        nextClipButton.onClick.AddListener(musicManager.NextClip);
        previousClipButton.onClick.AddListener(musicManager.PreviousClip);
    }
}
