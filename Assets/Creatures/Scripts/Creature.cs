using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour, IGetDamaged
{
    public float speed;

    public int healthMax;
    public float health;
    public float healthChargeRate;

    public int energyMax;
    public float energy;
    public float energyChargeRate;

    public Rigidbody2D rb;
    protected Animator animator;


    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            energy += Time.deltaTime * energyChargeRate;
        }
    }

    protected virtual void ChargingHealth()
    {
        if (healthMax > health)
        {
            health += Time.deltaTime * healthChargeRate;
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
            animator.SetBool("dead", true);

            //postac umarla i nie zyje
            //i co dalej?
            AfterDeath();

        }
        else
        {
            animator.SetBool("getDamage", true);

            yield return new WaitForSeconds(0.01F);

            animator.SetBool("getDamage", false);
        }
    }

    protected virtual void AfterDeath()
    {

    }
}
