using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    public GameObject explosion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (target != null)
        {
            target.GetDamage(damage);
            Explosion();
        }

        if (collision.GetComponent<IBulletDestroyable>() != null)
        {
            Explosion();
        }

    }

    private void Explosion()
    {
        Instantiate(explosion, currentTransform.position, currentTransform.rotation);
        Destroy(gameObject);
    }

    protected override void EndofRange()
    {
        Explosion();
        //wybuch
    }
}
