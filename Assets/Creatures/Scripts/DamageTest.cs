using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    public HeroManager hero;

    // Start is called before the first frame update
    void Start()
    {
        hero = FindObjectOfType<HeroManager>();
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
}
