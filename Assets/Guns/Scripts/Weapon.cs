using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public Rigidbody2D rb;

    Vector2 mousePosition;
    float time;
  
    // Start is called before the first frame update
    void Start()
    {

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
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        rb.rotation = angle;
    }

    public virtual void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
