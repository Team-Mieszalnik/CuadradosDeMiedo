using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour, IGetDamaged, ICanSetOnFire
{
    public float speed;

    public int healthMax;
    public float health;
    public float healthRegeneration;

    public int energyMax;
    public float energy;
    public float energyRegeneration;

    public Rigidbody2D rb;
    protected Animator animator;

    protected bool ignite;
    protected float fireTime;



    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        ignite = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected void FixedUpdate()
    {
        ChargingEnergy();
        ChargingHealth();
    }


    protected virtual void ChargingEnergy()
    {
        if (energyMax > energy)
        {
            energy += Time.deltaTime * energyRegeneration;
        }
    }

    protected virtual void ChargingHealth()
    {
        if (healthMax > health)
        {
            health += Time.deltaTime * healthRegeneration;
        }
    }


    public virtual void GetDamage(float damage)
    {
        health -= damage;
        StartCoroutine(GetDamageAnimation());
    }

    protected virtual IEnumerator GetDamageAnimation()
    {
        if (health <= 0)
        {
            if (gameObject.GetComponent<PolygonCollider2D>().enabled == true) 
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                animator.SetBool("dead", true);

                //postac umarla i nie zyje
                //i co dalej?
                StartCoroutine(AfterDeath());
            }
        }
        else
        {
            animator.SetBool("getDamage", true);

            yield return new WaitForSeconds(0.01F);//animation time

            animator.SetBool("getDamage", false);
        }
    }

    protected virtual IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(0.01F);//animation time
    }



    public IEnumerator GetFireDamage(float damage, float time)
    {
        fireTime = time;

        if (ignite) 
        {
            ignite = false;
            gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = true;

            while (fireTime > 0) 
            {
                health -= damage;
                StartCoroutine(GetDamageAnimation());
                yield return new WaitForSeconds(0.1F);//animation time

                fireTime -= 0.1F;//animation time
            }

            gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
            ignite = true;
        }
    }
}
