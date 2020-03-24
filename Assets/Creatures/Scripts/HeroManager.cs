using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public float speed;

    public int healthMax;
    public float health;
    public float healthChargeRate;

    public int energyMax;
    public float energy;
    public float energyChargeRate;

    private bool energyIsUsed = false;



    public Rigidbody2D hero;
    private Animator animator;
    //private Transform tf;

    //private Ray ray;




    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    private void FixedUpdate()
    {
        ChargingEnergy();
        ChargingHealth();
    }


    private void Control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            hero.velocity = new Vector2(hero.velocity.x, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            hero.velocity = new Vector2(hero.velocity.x, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            hero.velocity = new Vector2(-speed, hero.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            hero.velocity = new Vector2(speed, hero.velocity.y);
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

    private void ChargingEnergy()
    {
        if (energyMax > energy) 
        {
            energy += Time.deltaTime * energyChargeRate;
        }
    }

    private void ChargingHealth()
    {
        if (healthMax > health)
        {
            health += Time.deltaTime * healthChargeRate;
        }
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

    public IEnumerator GetDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetBool("dead", true);

            //postac umarla i nie zyje
            //i co dalej?
        }
        else
        {
            animator.SetBool("getDamage", true);

            yield return new WaitForSeconds(0.01F);

            animator.SetBool("getDamage", false);
        }
    }
}
