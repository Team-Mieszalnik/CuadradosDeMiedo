using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampSurface : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            return;
        }


        Creature target = collision.GetComponent<Creature>();

        if (target != null)
        {
            target.speed -= 3.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            return;
        }


        Creature target = collision.GetComponent<Creature>();

        if (target != null)
        {
            target.speed += 3.5f;
        }
    }
}
