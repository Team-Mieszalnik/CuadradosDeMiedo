using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssSurfaces : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Triangle")
        {
            return;
        }

        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (target != null)
        {
            target.GetDamage(10000);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Triangle")
        {
            return;
        }


        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (target != null)
        {
            target.GetDamage(10000);
        }
    }
}
