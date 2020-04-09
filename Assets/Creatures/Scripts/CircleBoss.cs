using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoss : Circle
{
        protected override IEnumerator Attack()
    {
        attacking = AlternativeAttack;
        yield return new WaitForSeconds(0.1F);
    }

    protected override IEnumerator AlternativeAttack()
    {
        attack = true;
        for(int i=0; i<3; i++)
        {
            animator.SetBool("attack", true);
            yield return new WaitForSeconds(0.5F);//animation time
            Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek
		    animator.SetBool("attack", false);
        }
        yield return new WaitForSeconds(Random.Range(1F, 2F));//attack time
        attack = false;
    }
}
