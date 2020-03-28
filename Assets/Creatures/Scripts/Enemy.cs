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


    protected override IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(0.5F);//animation time
        Destroy(gameObject);
    }


}
