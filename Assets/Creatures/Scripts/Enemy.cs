using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }



    protected override IEnumerator GetDamageAnimation()
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

            yield return new WaitForSeconds(0.5F);

            animator.SetBool("getDamage", false);
        }
    }

}
