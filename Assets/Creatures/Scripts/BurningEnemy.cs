using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
