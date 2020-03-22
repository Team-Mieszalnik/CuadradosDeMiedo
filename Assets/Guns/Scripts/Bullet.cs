using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float range;
    public float bulletSpeed;
    public Transform currentTransform;
    public Rigidbody2D rb;
    Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = currentTransform.position;

        //rb.velocity = currentTransform.right * bulletSpeed;
        rb.AddForce(currentTransform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if ((startPoint - currentTransform.position).magnitude > range)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collision == enemy zadaj obrazenia

        //tak czy siak jak trafi na jakakolwiek przeszkode to sie dezintegruje
        if (collision.GetComponent<Bullet>() == null)
            Destroy(gameObject);
    }
}
