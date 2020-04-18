using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSetOnFire
{
    IEnumerator GetFireDamage(float damage, float time);
}
