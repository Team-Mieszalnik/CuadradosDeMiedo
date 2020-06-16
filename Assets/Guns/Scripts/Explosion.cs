using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

/**
* @brief
* klasa odpowiadajaca za wybuch np granatu i zadanie obrazen w danym obszarze przecinwkiom
*/
public class Explosion : MonoBehaviour
{
    Light2D light2D;

    public float damage;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        StartCoroutine(KabumAnimation());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if(target != null)
        {
            target.GetDamage(damage);
        }
    }


    protected virtual IEnumerator KabumAnimation()
    {
        yield return new WaitForSeconds(2.2f);
        Destroy(gameObject);
    }
}
