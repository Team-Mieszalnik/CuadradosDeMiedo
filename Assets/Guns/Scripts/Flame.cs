using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private ParticleSystem PSystem;
    private List<ParticleCollisionEvent> CollisionEvents;

    public float damage;

    void Start()
    {
        PSystem = GetComponent<ParticleSystem>();
        CollisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        IGetDamaged target = other.GetComponent<IGetDamaged>();

        if (target != null)
        {
            target.GetDamage(damage);
        }

        //int collCount = PSystem.GetSafeCollisionEventSize();

        //int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);

        //for (int i = 0; i < eventCount; i++)
        //{
        //    //TODO: Do your collision stuff here. 
        //    // You can access the CollisionEvent[i] to obtaion point of intersection, normals that kind of thing
        //    // You can simply use "other" GameObject to access it's rigidbody to apply force, or check if it implements a class that takes damage or whatever
        //}

    }
}

