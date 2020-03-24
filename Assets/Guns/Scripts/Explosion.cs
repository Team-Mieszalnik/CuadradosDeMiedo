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
        IGetDamaged[] hits = collision.GetComponents<IGetDamaged>();

        foreach(var hit in hits)
        {
            hit.GetDamage(damage);
        }
    }


    protected virtual IEnumerator KabumAnimation()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
