using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject[] lootWeapons;
    public float chance;

    public void LootItem()
    {
        if(Random.Range(0,101) <= chance)
        {
            int item = Random.Range(0, lootWeapons.Length - 1);

            Instantiate(lootWeapons[item], transform.position, Quaternion.identity);

        }
    }

}
