﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

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
