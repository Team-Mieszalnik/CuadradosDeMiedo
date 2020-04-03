using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWeapons : Weapon
{
    public GameObject cast;

    private void Awake()
    {
        cast.SetActive(false);
    }

    protected override void Control()
    {
        if (Input.GetMouseButton(0))
        {
            cast.SetActive(true);
            if (!audioSource.isPlaying)
                audioSource.Play();
            // Shoot();
            //StartCoroutine(ShootAnimation());
            ammo -= 10 * Time.deltaTime;
        }
        else
        {
            audioSource.Stop();
            cast.SetActive(false);
        }
    }
}
