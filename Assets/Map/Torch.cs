using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
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

    protected IEnumerator Fire()
    {
        next = false;

        yield return new WaitForSeconds(0.3F);

        light2D.intensity = Random.Range(0.5f, 0.8f);

        next = true;
    }
}
