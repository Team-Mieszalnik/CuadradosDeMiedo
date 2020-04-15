using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWeapons : Weapon
{
    public GameObject cast;
    private bool isLoop = false;
    public AudioClip startClip;
    public AudioClip loopClip;

    private AudioSource ASstart;
    private AudioSource ASloop;


    private void Awake()
    {
        cast.SetActive(false);
        ASstart = gameObject.AddComponent<AudioSource>();
        ASstart.clip = startClip;
        ASstart.loop = false;
        ASloop = gameObject.AddComponent<AudioSource>();
        ASloop.clip = loopClip;
        ASloop.loop = true;
    }

    protected override void Control()
    {
        if (Input.GetMouseButton(0))
        {
            cast.SetActive(true);
            Loop();
            // Shoot();
            //StartCoroutine(ShootAnimation());
            ammo -= 10 * Time.deltaTime;
        }
        else
        {
            StopLoop();
            cast.SetActive(false);
        }
    }

    float initialDelay = 0.1f;
    private void Loop()
    {
        if (isLoop == false)
        {
            isLoop = true;
            ASstart.Play();
            ASloop.PlayDelayed(startClip.length-initialDelay);
        }
    }
    private void StopLoop()
    {
        isLoop = false;
        ASstart.Stop();
        ASloop.Stop();
    }
}
