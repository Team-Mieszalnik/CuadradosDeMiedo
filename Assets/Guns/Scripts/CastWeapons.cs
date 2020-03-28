using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWeapons : Weapon
{
    public GameObject cast;

    protected override void Control()
    {
        if (Input.GetMouseButton(0))
        {
            cast.SetActive(true);
            // Shoot();
            StartCoroutine(ShootAnimation());
        }
        else
        {
            cast.SetActive(false);
        }
    }
}
