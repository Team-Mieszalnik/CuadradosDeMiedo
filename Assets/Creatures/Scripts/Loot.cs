using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
     * @brief
     * klasa odpowiedzialna za wyrzucanie przedmiotów z pokonanych przeciwników
     */
public class Loot : MonoBehaviour
{
    public GameObject[] lootWeapons;
    public float chance;

    /**
     * @brief
     * metoda odpowiedzialna za losowanie wyrzucania przedmiotów
     */
    public void LootItem()
    {
        if(Random.Range(0,101) <= chance)
        {
            int item = Random.Range(0, lootWeapons.Length);

            Instantiate(lootWeapons[item], transform.position, Quaternion.identity);

        }
    }

}
