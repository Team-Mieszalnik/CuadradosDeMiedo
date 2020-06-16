using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
    * @brief
    * klasa broni miotacza ognia/laserguna 
*/
public class CastWeapons : Weapon
{
    public GameObject cast;
    public AudioClip startClip;
    public AudioClip loopClip;

    /**
    * @brief
    * metoda wywolywana na poczatku uzywania broni
    */
    protected override void StartShooting()
    {
        base.StartShooting();
        cast.SetActive(true);
        audioSource.PlayOneShot(startClip);
        audioSource.loop = false;
    }
    /**
    * @brief
    * metoda wywolywana na koncu uzywania broni
    */
    protected override void StopShooting()
    {
        base.StopShooting();
        cast.SetActive(false);
        audioSource.Stop();
    }
    /**
    * @brief
    * metoda wywolywana w trakcie strzelanai bronia
    */
    protected override void Shooting()
    {
        ammo -= 10 * Time.deltaTime;

        if (!audioSource.isPlaying) { audioSource.PlayOneShot(loopClip); audioSource.loop = true; }
    }

}
