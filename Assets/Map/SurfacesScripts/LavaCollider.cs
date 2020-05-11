using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LavaCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");

        Physics.IgnoreCollision(hero.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero") 
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<TilemapCollider2D>());
        }

        if (collision.gameObject.tag == "Triangle")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<TilemapCollider2D>());
        }
    }

}
