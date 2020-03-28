using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

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


    public void SetMusic(float volume)
    {

    }

    public void SetQuality(float quality)
    {

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
