using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    /**
    * @brief
    * metoda odpowiadajaca za instancjonowanie prefaba pocisku/ów i ustawienie kierunku w jakim ma byc wystrzelony
    */
    protected override void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
