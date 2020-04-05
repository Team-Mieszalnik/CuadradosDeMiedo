using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSurface : MonoBehaviour
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
        Creature target = collision.GetComponent<Creature>();

        if (target != null)
        {
            target.speed += 3;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Creature target = collision.GetComponent<Creature>();

        if (target != null)
        {
            target.speed -= 3;

        }
    }
}
