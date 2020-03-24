using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Creature
{
    protected bool energyIsUsed = false;


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

        if (Input.GetKey(KeyCode.Space) && !energyIsUsed)
        {
            StartCoroutine(UseEnergy());
        }

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (ray.origin.x > tf.position.x)
        //{
        //    tf.localRotation = new Quaternion(tf.localRotation.x, 0, tf.localRotation.z, tf.localRotation.w);
        //}
        //else
        //{
        //    tf.localRotation = new Quaternion(tf.localRotation.x, 1f, tf.localRotation.z, tf.localRotation.w);
        //}
    }

    private IEnumerator UseEnergy()
    {
        if (energy > 10)
        {
            energyIsUsed = true;
            animator.SetBool("useEnergy", true);
            energy -= 10;
            speed *= 2;

            yield return new WaitForSeconds(1);

            speed /= 2;
            animator.SetBool("useEnergy", false);
            energyIsUsed = false;
        }
    }
}
