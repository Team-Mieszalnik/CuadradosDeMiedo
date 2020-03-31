using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float range;
    public float bulletSpeed;
    protected Rigidbody2D rb;
    protected Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        startPoint = transform.position;

        //rb.velocity = currentTransform.right * bulletSpeed;
        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if ((startPoint - transform.position).magnitude > range)
            EndofRange();
    }

    protected virtual void EndofRange()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IGetDamaged target = collision.GetComponent<IGetDamaged>();

        if (target != null )
        {
            target.GetDamage(damage);
            Destroy(gameObject);
        }

        //IBulletDestroyable detory = collision.GetComponent<IBulletDestroyable>();

        if (collision.GetComponent<IBulletDestroyable>() != null)
        {
            Destroy(gameObject);
        }

    }
}
