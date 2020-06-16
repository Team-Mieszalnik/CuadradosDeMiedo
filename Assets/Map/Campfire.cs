using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

/**
    * @brief
    * Klasa zarzadzajaca ogniskiem
    */
public class Campfire : MonoBehaviour
{
    protected Light2D light2D;

    protected bool next;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        next = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            StartCoroutine(Fire());
        }
    }

    /**
        * @brief
        * Metoda ustawiajaca ogien w ognisku
        */
    protected IEnumerator Fire()
    {
        next = false;

        yield return new WaitForSeconds(0.5F);

        light2D.intensity = Random.Range(0.3f, 0.6f);

        next = true;
    }
}
