using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject[] lootWeapons;
    public GameObject enemies;
    public float chance;
    public int numberOfEnemies; // how many enemies to be spawned

    public void LootItem()
    {
        if(Random.Range(0,101) <= chance)
        {
            int item = Random.Range(0, lootWeapons.Length - 1);

            Instantiate(lootWeapons[item], transform.position, Quaternion.identity);

        }

        for(int i=0; i<numberOfEnemies; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition = transform.position;
            newPosition.x += (i - (numberOfEnemies/2)) * 2;
            newPosition.y += (i - (numberOfEnemies/2)) * 2;
            Instantiate(enemies, newPosition, Quaternion.identity);
        }
    }

}
