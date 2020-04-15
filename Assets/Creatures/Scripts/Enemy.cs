using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spawnable;
    protected Transform hero;

    Vector2 moveDirection;


    protected bool attack = false;
    protected bool alternateMove = false;
    protected bool moveRandomizer = false;

    protected delegate IEnumerator movingDelegate();
    protected movingDelegate moving;

    protected delegate IEnumerator attackDelegate();
    protected attackDelegate attacking;


    public float distance;
    public float move;

    public int Exp;


    // Update is called once per frame
    void Update()
    {
        hero = GameObject.Find("Hero").transform;
        
        if (!moveRandomizer)
        {
            StartCoroutine(Move());
        }
        StartCoroutine(moving());

        if (!attack)
        {
            StartCoroutine(Attack());
            StartCoroutine(attacking());
        }
    }

    protected virtual IEnumerator Attack()
    {
        switch (Random.Range(0, 100))
        {
            case int n when (n > 30):
                attacking = StandardAttack;
                break;
            default:
                attacking = AlternativeAttack;
                break;
        }
        yield return new WaitForSeconds(0.1F);
    }

    protected virtual IEnumerator StandardAttack()
    {
        attack = true;
        animator.SetBool("attack", true);

        yield return new WaitForSeconds(1.5F);//animation time

        Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek


		animator.SetBool("attack", false);
		yield return new WaitForSeconds(Random.Range(2F, 4F));//attack time
        attack = false;
    }

    protected virtual IEnumerator AlternativeAttack()
    {
        attack = true;
        animator.SetBool("attack", true);

        yield return new WaitForSeconds(1.5F);//animation time

        Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek


		animator.SetBool("attack", false);
		yield return new WaitForSeconds(Random.Range(2F, 4F));//attack time
        attack = false;
    }

    protected IEnumerator Move()
    {
        moveRandomizer = true;
        switch (Random.Range(0, 100))
        {
            case int n when (n >= move):
                moving = StandardMove;
                yield return new WaitForSeconds(4F);
                break;
            default:
                moving = AlternativeMove;
                yield return new WaitForSeconds(1F);
                break;
        }
        // moves delay
        moveRandomizer = false;
        alternateMove = false;
    }




    protected IEnumerator StandardMove()
    {
        Vector2 moveDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
        if(moveDirection.magnitude >= distance)
        {
            rb.velocity = moveDirection.normalized * speed;
        }
        yield return new WaitForSeconds(0);
    }

    protected IEnumerator AlternativeMove()
    {
        if(!alternateMove)
        {
            moveDirection = new Vector2(Random.Range(-10,10), Random.Range(-10,10));
            alternateMove = true;
        }
        rb.velocity = moveDirection.normalized * speed;
        yield return new WaitForSeconds(0);
    }
    
   


    protected override IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(1F);//animation time

        animator.SetBool("dead", false);

        Destroy(gameObject);

        Experience.addDefeatedOpponents(Exp);
        LevelController.DecrementEnemyCounter();

                var loot = GetComponent<Loot>();
        if (loot != null) loot.LootItem();

    }


}
