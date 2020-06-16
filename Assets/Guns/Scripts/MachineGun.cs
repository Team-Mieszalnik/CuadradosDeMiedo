using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    public int bulletPerSalvo;
    public float timeBetweenBullets;

    /**
    * @brief
    * metoda odpowiadajaca za instancjonowanie prefaba pocisku/ów i ustawienie kierunku w jakim ma byc wystrzelony
    */
    protected override void Shoot()
    {
        StartCoroutine(Salvo());
    }

    IEnumerator Salvo()
    {
        for(int i=0; i< bulletPerSalvo; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(timeBetweenBullets);
        }
    }
}
