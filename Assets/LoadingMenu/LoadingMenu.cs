using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMenu : MonoBehaviour
{

    public TextMeshProUGUI mapName;

    public void Update()
    {
        mapName.text = MapController.SceneName;
    }
}
