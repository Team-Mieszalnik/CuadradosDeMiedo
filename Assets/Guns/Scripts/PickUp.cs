using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject weapon;
    public GameObject hando;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon target = collision.GetComponent<Weapon>();
        if (target != null)
        {
            if (weapon != null)
            {
                Destroy(weapon);
                //weapon.transform.position = new Vector3(hando.transform.position.x, hando.transform.position.y, hando.transform.position.z);
                //weapon.transform.parent = null;
                //weapon.GetComponent<Weapon>().isActive = false;
            }

            weapon = target.gameObject;
            weapon.transform.position = hando.transform.position;
            weapon.transform.parent = hando.transform;
            weapon.GetComponent<Weapon>().isActive = true;

        }


    }
}
