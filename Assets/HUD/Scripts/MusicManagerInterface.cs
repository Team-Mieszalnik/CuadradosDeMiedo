using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerInterface : MonoBehaviour
{
    public Button startStopMusicButton;
    public Button nextClipButton;
    public Button previousClipButton;
    //public Text startStopButtonText;
    private MusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        //gameObject.transform.Find("StartStopMusic Button").GetComponent<Button>().onClick.AddListener(musicManager.StartStopFunction);
        startStopMusicButton = startStopMusicButton.GetComponent<Button>();
        nextClipButton = nextClipButton.GetComponent<Button>();
        previousClipButton = previousClipButton.GetComponent<Button>();
        startStopMusicButton.onClick.AddListener(musicManager.StartStopFunction);
        nextClipButton.onClick.AddListener(musicManager.NextClip);
        previousClipButton.onClick.AddListener(musicManager.PreviousClip);
    }
}
