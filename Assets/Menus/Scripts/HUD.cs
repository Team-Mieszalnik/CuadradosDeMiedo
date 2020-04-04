using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //public Text heroHealthText;
    //public Text heroEnergyText;
    public Text heroAmmoText;

    public Slider heroEnergyBar;
    public Slider heroHealthBar;

    private Hero hero;
    private PickUp pickUpWeapon;


    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        pickUpWeapon = GameObject.FindGameObjectWithTag("Hero").GetComponent<PickUp>();

        heroHealthBar.maxValue = hero.healthMax;
        heroEnergyBar.maxValue = hero.energyMax;
    }

    // Update is called once per frame
    void Update()
    {
        //heroHealthText.text = ((int)hero.health).ToString();
        //heroEnergyText.text = ((int)hero.energy).ToString();
        string ammo = ((int)pickUpWeapon.weapon.GetComponent<Weapon>().ammo).ToString();
        if (ammo == "-2147483648")
            ammo = "∞";


        heroAmmoText.text = ammo;

        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
    }
}
