using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    protected override void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    protected override IEnumerator ShootAnimation()
    {
        yield return new WaitForSeconds(0);
    }
}
