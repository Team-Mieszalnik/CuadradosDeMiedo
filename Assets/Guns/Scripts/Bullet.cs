using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float range;
    public float bulletSpeed;
    protected Transform currentTransform;
    protected Rigidbody2D rb;
    protected Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentTransform = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();

        startPoint = currentTransform.position;

        //rb.velocity = currentTransform.right * bulletSpeed;
        rb.AddForce(currentTransform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if ((startPoint - currentTransform.position).magnitude > range)
            EndofRange();
    }

    protected virtual void EndofRange()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
