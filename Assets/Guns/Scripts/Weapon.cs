using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public Rigidbody2D rb;

    Camera cam;
    Transform tf;
    Vector2 mousePosition;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        tf = this.GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //if(Input.GetButtonDown("Fire1"))
        if (Input.GetMouseButton(0) && time > attackSpeed)
        {
            time = 0;
            Shoot();
        }

        time += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - new Vector2(tf.position.x, tf.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        tf.rotation = Quaternion.Euler(0, 0, angle);
    }

    public virtual void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
