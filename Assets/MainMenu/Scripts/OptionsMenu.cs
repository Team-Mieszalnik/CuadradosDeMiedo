using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        //resolutions = Screen.resolutions;
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();


        resolutionDropdown.ClearOptions();

        List<string> resolutionsString = new List<string>();

        int currentRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionsString.Add(resolutions[i].width + " x " + resolutions[i].height);
            if (Screen.width == resolutions[i].width && Screen.height == resolutions[i].height)
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
