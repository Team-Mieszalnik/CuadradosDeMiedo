using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/**
    * @brief
    * klasa odpowiadajaca za wyswietlania nazwy poziomu numeru poziomu i obrazka mapy na ekranie ładowania
*/
public class LoadingMenu : MonoBehaviour
{

    public TextMeshProUGUI mapName;
    public TextMeshProUGUI levelName;
    public Image map;

    public Sprite[] mapPrevies;

    public void ContinueGame()
    {
        MusicManager.StartMap();
        MapController.GoNextLevel();
    }

    public void Update()
    {
        mapName.text = MapController.SceneName;
        levelName.text = "LEVEL " + LevelController.Level.ToString();
        map.sprite = StringToSprite(MapController.SceneName);
    }

    private Sprite StringToSprite(string mapName)
    {

        switch (mapName)
        {
            case "Arena":
                return mapPrevies[0];
            case "Invierno":
                return mapPrevies[1];
            case "Primavera":
                return mapPrevies[2];
            case "Vesuvio":
                return mapPrevies[3];
            case "Cueva":
                return mapPrevies[4];
            case "Boss":
                return mapPrevies[5];

        }
        return mapPrevies[0];
    }


}
