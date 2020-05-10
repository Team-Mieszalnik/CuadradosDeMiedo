using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWeapons : Weapon
{
    public GameObject cast;
    public AudioClip startClip;
    public AudioClip loopClip;

    protected override void StartShooting()
    {
        base.StartShooting();
        cast.SetActive(true);
        audioSource.PlayOneShot(startClip);
        audioSource.loop = false;
    }

    protected override void StopShooting()
    {
        base.StopShooting();
        cast.SetActive(false);
        audioSource.Stop();
    }

    protected override void Shooting()
    {
        ammo -= 10 * Time.deltaTime;

        if (!audioSource.isPlaying) { audioSource.PlayOneShot(loopClip); audioSource.loop = true; }
    }

}
