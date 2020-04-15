using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBoss : Square
{
    protected override IEnumerator Attack()
    {
        switch (Random.Range(0, 100))
        {
            case int n when (n > 10):
                attacking = StandardAttack;
                break;
            default:
                attacking = AlternativeAttack;
                break;
        }
        yield return new WaitForSeconds(0.1F);
    }

    protected override IEnumerator StandardAttack()
    {
        attack = true;
        animator.SetBool("attack", true);

        yield return new WaitForSeconds(1.5F);//animation time
        Vector2 lookDirection = new Vector2(hero.position.x, hero.position.y) - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek


		animator.SetBool("attack", false);
		yield return new WaitForSeconds(Random.Range(1F, 2F));//attack time
        attack = false;
    }
    protected override IEnumerator AlternativeAttack()
    {
        attack = true;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1.5F);//animation time

        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x += 3;
        newPosition.y += 3;
        Instantiate(spawnable, newPosition, Quaternion.identity);

        animator.SetBool("attack", false);
        yield return new WaitForSeconds(Random.Range(1F, 2F));//attack time
        attack = false;
    }
}
