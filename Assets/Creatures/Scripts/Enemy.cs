using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{


  public GameObject bulletPrefab;
  public Transform hero;
	protected bool attack = false;




    // Update is called once per frame
    void Update()
    {
      hero = GameObject.Find("Hero").transform;

		  if(!attack)
		    {
			    StartCoroutine(Attack());
		    }
    }

    protected IEnumerator Attack()
    {
		  attack = true;
      animator.SetBool("attack", true);

      Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
      float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

      Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek
      yield return new WaitForSeconds(1F);//animation time
		  animator.SetBool("attack", false);
		  yield return new WaitForSeconds(2F);//attack time
		  attack = false;
    }


    protected override IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(1F);//animation time
        Destroy(gameObject);
    }


}
