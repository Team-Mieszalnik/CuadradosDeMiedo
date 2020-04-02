using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hero : Creature
{
    [HideInInspector] public float damageReduction = 1;

    protected Ray ray;


    // Update is called once per frame
    void Update()
    {
        Control();
    }


    private void Control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ray.origin.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }


    public override void GetDamage(float damage)
    {
        health -= damage / damageReduction;

        StartCoroutine(GetDamageAnimation());
    }

    protected override IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(2F);
        animator.SetBool("dead", false);
        for (int i = 0; i < 401; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
            yield return new WaitForSeconds(0.0005F);//animation time
        }
    }
}
