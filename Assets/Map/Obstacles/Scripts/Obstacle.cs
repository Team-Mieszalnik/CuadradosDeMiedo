using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IGetDamaged, IBulletDestroyable
{
    public float hp;

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
              Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<Bullet>() != null)
    //        if (--hp <= 0)
    //            Destroy(gameObject);
    //}
}
