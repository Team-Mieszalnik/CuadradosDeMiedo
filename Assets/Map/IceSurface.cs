using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSurface : MonoBehaviour
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
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            return;
        }


        Rigidbody2D target = collision.GetComponent<Rigidbody2D>();

        if (target != null)
        {
            target.drag -= 9.9f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            return;
        }


        Rigidbody2D target = collision.GetComponent<Rigidbody2D>();

        if (target != null)
        {
            target.drag += 9.9f;

        }
    }
}
