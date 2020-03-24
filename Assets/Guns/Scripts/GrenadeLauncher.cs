using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Gun
{
    protected override void Shoot()
    {
        GameObject gobject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Grenade grenade = gobject.GetComponent<Grenade>();
        float mouseDistance = (firePoint.position - new Vector3(mousePosition.x, mousePosition.y)).magnitude;
        grenade.range = mouseDistance > grenade.range ? grenade.range : mouseDistance;
    }



}
