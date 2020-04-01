using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;

    void Start()
    {
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
