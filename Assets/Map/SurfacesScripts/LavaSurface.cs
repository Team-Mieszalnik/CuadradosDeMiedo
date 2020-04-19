using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gun" || collision.gameObject.tag == "Triangle")
        {
            return;
        }

        ICanSetOnFire target = collision.GetComponent<ICanSetOnFire>();

        if (target != null) 
        {
            StartCoroutine(target.GetFireDamage(0.5f, 2));
        }
    }
}
