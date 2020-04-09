using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSurface : MonoBehaviour
{
    bool ignite;

    // Start is called before the first frame update
    void Start()
    {
        ignite = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ignite == true) 
        {
            StartCoroutine(Fire(collision));
        }
    }

    private IEnumerator Fire(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();
        if (target != null)
        {
            target.GetDamage(1);
        }

        ignite = false;
        yield return new WaitForSeconds(0.5f);

        ignite = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ignite = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ignite = true;
    }
}
