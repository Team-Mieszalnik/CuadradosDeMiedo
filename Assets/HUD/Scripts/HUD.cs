using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //public Text heroHealthText;
    //public Text heroEnergyText;

    public Image cureCooldown;
    public TextMeshProUGUI enemyLeft;
    public Text heroAmmoText;

    public Slider heroEnergyBar;
    public Slider heroHealthBar;
    public Slider heroExpirienceBar;

    public Button HPUpgarade;
    public Button MovementUpgrade;

    private Hero hero;
    private PickUp pickUpWeapon;
    private Skills skills;
    private Experience experience;

    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        pickUpWeapon = GameObject.FindGameObjectWithTag("Hero").GetComponent<PickUp>();
        skills = GameObject.FindGameObjectWithTag("Hero").GetComponent<Skills>();
        experience = GameObject.FindGameObjectWithTag("Hero").GetComponent<Experience>();

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
            ammo = "INF";//"∞";
        heroAmmoText.text = ammo;

        enemyLeft.text = LevelController.enemyCounter.ToString();

        cureCooldown.color = skills.CureReady ? Color.green : Color.gray;

        HPUpgarade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        MovementUpgrade.image.color = experience.CanMovementUpgrade() ? Color.yellow : Color.grey;

        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
        heroExpirienceBar.value = Experience.points;
    }

    public void UpgradeHP()
    {
        experience.HealthLevelUpgrade();
        heroHealthBar.maxValue = hero.healthMax;
    }

    public void UpgradeMovement()
    {
        experience.MovementLevellUpgrade();
    }


}
