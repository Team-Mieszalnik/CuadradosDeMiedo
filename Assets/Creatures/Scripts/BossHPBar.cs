using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public Creature creature;
    private Slider hp;


    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Slider>();
        hp.maxValue = creature.healthMax;
        hp.value = creature.health;
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = creature.health;
    }
}
