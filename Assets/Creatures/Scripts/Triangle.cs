using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class Triangle : Enemy
{
    protected Light2D light2D;

    protected override IEnumerator AlternativeAttack()
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
        yield return new WaitForSeconds(Random.Range(2F, 4F));//attack time
        attack = false;
    }
}
