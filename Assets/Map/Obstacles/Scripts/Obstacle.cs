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
}
