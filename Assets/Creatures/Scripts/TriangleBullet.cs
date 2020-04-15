using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBullet : Bullet
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (collision.gameObject.tag == "Wall") 
        {
            //Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<TilemapCollider2D>());
            return;
        }

        if(collision.gameObject.tag == "Square")
        {
            return;
        }

        if(collision.gameObject.tag == "Triangle")
        {
            return;
        }

        if(collision.gameObject.tag == "Ciercle")
        {
            return;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            return;
        }

        if (collision.gameObject.tag == "Gun")
        {
            return;
        }

        if(collision.gameObject.tag == "EnemyBullet")
        {
            return;
        }

        if (collision.gameObject.tag == "Surface") 
        {
            return;
        }

        if (target != null)
        {
            target.GetDamage(damage);
        }
        
        Destroy(gameObject);
    } 
    
}
