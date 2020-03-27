using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public GameObject Flame;
    protected Camera cam;
    protected Vector2 mousePosition;

    // Start is called before the first frame update
    protected void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //if(Input.GetButtonDown("Fire1"))
        if (Input.GetMouseButton(0))
        {
            Flame.SetActive(true);

            //StartCoroutine(ShootAnimation());
        }
        else
        {
            Flame.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        //tf.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePosition.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(180f, 0, -angle);
        }
    }

}
