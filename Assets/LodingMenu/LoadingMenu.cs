using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        MapController.GoNextLevel();
    }
}
