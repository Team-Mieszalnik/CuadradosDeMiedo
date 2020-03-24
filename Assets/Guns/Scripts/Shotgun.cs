using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    protected override void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 15f));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -15f));
    }

    protected override IEnumerator ShootAnimation()
    {
        animator.SetBool("shoot", true);

        yield return new WaitForSeconds(0.83f);

        animator.SetBool("shoot", false);
    }

}
