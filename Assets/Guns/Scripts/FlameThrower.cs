using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : CastWeapons
{
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
        GetComponent<PolygonCollider2D>().enabled = true;
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
        GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("TAG: " + collision.gameObject.tag);
        Debug.Log("isActive: " + isActive);

        if ((collision.gameObject.tag != "Tringle" || collision.gameObject.tag != "Hero") && isActive == true)
        {
            ICanSetOnFire target = collision.GetComponent<ICanSetOnFire>();

            if (target != null)
            {
                StartCoroutine(target.GetFireDamage(0.5f, 2));
            }
        }
    }
}
