using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IGetDamaged
{
    public float hp;

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
              Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triangle")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<PolygonCollider2D>());
        }
    }

}
