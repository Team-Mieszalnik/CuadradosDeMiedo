using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamGun : Gun
{

    public GameObject laser;


    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //if(Input.GetButtonDown("Fire1"))
        if (Input.GetMouseButton(0))
        {
            laser.SetActive(true);
           // Shoot();
            StartCoroutine(ShootAnimation());
        }
        else
        {
            laser.SetActive(false);
        }

    }



    protected override void Shoot()
    {
        //laser.SetActive(true);


    }
}
