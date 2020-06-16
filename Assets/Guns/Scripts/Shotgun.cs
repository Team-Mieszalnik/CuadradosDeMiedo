using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    /**
    * @brief
    * metoda odpowiadajaca za instancjonowanie prefaba pocisku/ów i ustawienie kierunku w jakim ma byc wystrzelony
    */
    protected override void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 15f));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -15f));
    }
}
