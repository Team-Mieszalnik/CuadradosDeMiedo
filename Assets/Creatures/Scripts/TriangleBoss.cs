using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class TriangleBoss : Triangle
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
        light2D = GetComponent<Light2D>();
        attack = true;
        animator.SetBool("attack", true);
        light2D.intensity = 1;
        yield return new WaitForSeconds(1.5F);//animation time

        for(int i=0; i<8; i++)
        {
            float angle = i * Mathf.PI * 14;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle)); // obiekt, pozycja startowa, kierunek
		    
        }

        animator.SetBool("attack", false);
        light2D.intensity = 0;
        yield return new WaitForSeconds(Random.Range(1F, 2F));//attack time
        attack = false;
    }
    protected override IEnumerator AlternativeAttack()
    {
        light2D = GetComponent<Light2D>();
        attack = true;
        animator.SetBool("attack", true);
        light2D.intensity = 1;
        yield return new WaitForSeconds(1.5F);//animation time

        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x += 3;
        newPosition.y += 3;
        Instantiate(spawnable, newPosition, Quaternion.identity);
        LevelController.IncrementEnemyCounter();

        animator.SetBool("attack", false);
        light2D.intensity = 0;
        yield return new WaitForSeconds(Random.Range(1F, 2F));//attack time
        attack = false;
    }
}
