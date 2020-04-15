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
    public Image weaponsImage;

    public Slider heroEnergyBar;
    public Slider heroHealthBar;
    public Slider heroExpirienceBar;

    public Button HealthUpgarade;
    public Button EnergyUpgarade;
    public Button MovementUpgrade;
    public Button CureUpgarade;
    public Button ArmorUpgarade;

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
        {
            ammo = "∞";//"INF";
            heroAmmoText.fontSize = 100;
        }
        else
        {
            heroAmmoText.fontSize = 60;
        }


        heroAmmoText.text = ammo;

        weaponsImage.sprite = pickUpWeapon.weapon.GetComponent<SpriteRenderer>().sprite;
        weaponsImage.SetNativeSize();


        enemyLeft.text = LevelController.enemyCounter.ToString();
        cureCooldown.color = skills.CureReady ? Color.green : Color.gray;


        //HealthUpgarade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //EnergyUpgarade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //MovementUpgrade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //CureUpgarade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //ArmorUpgarade.image.color = experience.CanHealthUpgrade() ? Color.yellow : Color.grey;


        //HealthUpgarade.image.color = experience.MaxHealthUpgare ? Color.blue : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //EnergyUpgarade.image.color = experience.MaxHealthUpgare ? Color.blue : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //MovementUpgrade.image.color = experience.MaxHealthUpgare ? Color.blue : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //CureUpgarade.image.color = experience.MaxHealthUpgare ? Color.blue : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        //ArmorUpgarade.image.color = experience.MaxHealthUpgare ? Color.blue : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;


        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
        heroExpirienceBar.value = Experience.points;


        if (Input.GetKeyDown(KeyCode.Alpha1)) UpgradeHealth();
        if (Input.GetKeyDown(KeyCode.Alpha2)) UpgradeEnergy();
        if (Input.GetKeyDown(KeyCode.Alpha3)) UpgradeMovement();
        if (Input.GetKeyDown(KeyCode.Alpha4)) UpgradeCure();
        if (Input.GetKeyDown(KeyCode.Alpha5)) UpgradeArmor();

    }

    public void UpgradeHealth()
    {
        experience.HealthLevelUpgrade();
        heroHealthBar.maxValue = hero.healthMax;
    }

    public void UpgradeEnergy()
    {
        experience.HealthLevelUpgrade();
        heroHealthBar.maxValue = hero.healthMax;
    }

    public void UpgradeMovement()
    {
        experience.MoveLevellUpgrade();
    }

    public void UpgradeArmor()
    {
        experience.MoveLevellUpgrade();
    }

    public void UpgradeCure()
    {
        experience.MoveLevellUpgrade();
    }


}
