using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * @brief Graphical Interface for managing music
 * Sends commands to MusicManager MusicManager
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
