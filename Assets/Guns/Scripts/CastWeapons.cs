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

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("TAG: " + collision.gameObject.tag);
    //    Debug.Log("isActive: " + isActive);

    //    //if (collision.gameObject.tag == "Tringle" && isActive == true)
    //    {
    //        ICanSetOnFire target = collision.GetComponent<ICanSetOnFire>();

    //        if (target != null)
    //        {
    //            StartCoroutine(target.GetFireDamage(0.5f, 2));
    //        }
    //    }
    //}

}
