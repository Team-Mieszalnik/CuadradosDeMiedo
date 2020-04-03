using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    public AudioMixer audioMixer;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionsString = new List<string>();

        int currentRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionsString.Add(resolutions[i].width + " x " + resolutions[i].height);
            if (Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
            {
                currentRes = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionsString);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetQuality(float quality)
    {
        QualitySettings.SetQualityLevel((int)quality);
    }

    public void SetFullscreen(bool isFullscrenn)
    {
        Screen.fullScreen = isFullscrenn;
    }

    public void SetResolution(int resoIndex)
    {
        Screen.SetResolution(resolutions[resoIndex].width, resolutions[resoIndex].height, Screen.fullScreen);
    }

}
