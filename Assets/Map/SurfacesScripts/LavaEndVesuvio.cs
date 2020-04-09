using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEndVesuvio : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.enemyCounter <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
