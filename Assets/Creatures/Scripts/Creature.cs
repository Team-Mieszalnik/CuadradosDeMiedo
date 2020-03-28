﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour, IGetDamaged
{
    public float speed;

    public int healthMax;
    public float health;
    public float healthRegeneration;
    public Text healthDisplay;

    public int energyMax;
    public float energy;
    public float energyRegeneration;

    public Rigidbody2D rb;
    protected Animator animator;


    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (healthDisplay != null)
            healthDisplay.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected void FixedUpdate()
    {
        ChargingEnergy();
        ChargingHealth();
        if (healthDisplay != null)
            healthDisplay.text = health.ToString();
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
        if (healthDisplay != null)
        {
            healthDisplay.text = health.ToString();
            Debug.Log("dziala");
        }
        else Debug.Log("nie dziala");

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

            yield return new WaitForSeconds(0.01F);//animation time

            animator.SetBool("getDamage", false);
        }
    }

    protected virtual void AfterDeath()
    {

    }
}
