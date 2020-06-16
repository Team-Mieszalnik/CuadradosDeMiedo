using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    * @brief
    * Interfejs zawierajacy metode do zadawania obrazen od ognia
    */
public interface ICanSetOnFire
{
    IEnumerator GetFireDamage(float damage, float time);
}
