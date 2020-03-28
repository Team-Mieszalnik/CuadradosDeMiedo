using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTest : MonoBehaviour, IGetDamaged
{

    public float health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (target != null)
        {
            target.GetDamage(10);
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;   
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("hitekmobek");
    }

}
