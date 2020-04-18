using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public GameObject miniMap;

    public Image cureCooldown;
    public TextMeshProUGUI enemiesLeft;
    public Text heroAmmoText;
    public Image weaponsImage;

    public Slider heroEnergyBar;
    public Slider heroHealthBar;
    public Slider heroExpirienceBar;

    public TextMeshProUGUI heroHealthText;
    public TextMeshProUGUI heroEnergyText;
    public TextMeshProUGUI heroExpirienceText;

    public Button HealthUpgarade;
    public Button EnergyUpgarade;
    public Button MovementUpgrade;
    public Button CureUpgarade;
    public Button ArmorUpgarade;

    private Hero hero;
    private PickUp pickUpWeapon;
    private Skills skills;
    private Experience experience;

    private static bool isMiniMapVisible = false;

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


        enemiesLeft.text = LevelController.enemyCounter.ToString();
        cureCooldown.color = skills.CureReady ? Color.green : Color.gray;

        heroHealthText.text =  ((int)hero.health).ToString() + " / " + ((int)hero.healthMax).ToString();
        heroEnergyText.text = ((int)hero.energy).ToString() + " / " + ((int)hero.energyMax).ToString();
        heroExpirienceText.text = Experience.points.ToString() + " / 10";


        HealthUpgarade.image.color = experience.healthLevel == experience.healthMaxLevel ? Color.magenta : experience.CanHealthUpgrade() ? Color.yellow : Color.grey;
        EnergyUpgarade.image.color = experience.energyLevel == experience.energyhMaxLevel ? Color.magenta : experience.CanEnergyUpgrade() ? Color.yellow : Color.grey;
        MovementUpgrade.image.color = experience.movementLevel == experience.movementMaxLevel ? Color.magenta : experience.CanMovementUpgrade() ? Color.yellow : Color.grey;
        CureUpgarade.image.color = experience.cureLevel == experience.cureMaxLevel ? Color.magenta : experience.CanCureUpgrade() ? Color.yellow : Color.grey;
        ArmorUpgarade.image.color = experience.armorLevel == experience.armorMaxLevel ? Color.magenta : experience.CanArmorUpgrade() ? Color.yellow : Color.grey;


        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
        heroExpirienceBar.value = Experience.points;


        if (Input.GetKeyDown(KeyCode.Alpha1)) UpgradeHealth();
        if (Input.GetKeyDown(KeyCode.Alpha2)) UpgradeEnergy();
        if (Input.GetKeyDown(KeyCode.Alpha3)) UpgradeMovement();
        if (Input.GetKeyDown(KeyCode.Alpha4)) UpgradeCure();
        if (Input.GetKeyDown(KeyCode.Alpha5)) UpgradeArmor();

        if (Input.GetKeyDown(KeyCode.M))
        {
            isMiniMapVisible = !isMiniMapVisible;
            miniMap.SetActive(isMiniMapVisible);
        }

    }

    public void UpgradeHealth()
    {
        experience.HealthLevelUpgrade();
        heroHealthBar.maxValue = hero.healthMax;
    }

    public void UpgradeEnergy()
    {
        experience.EnergyLevelUpgrade();
        heroHealthBar.maxValue = hero.healthMax;
    }

    public void UpgradeMovement()
    {
        experience.MovementLevellUpgrade();
    }

    public void UpgradeCure()
    {
        experience.CureLevellUpgrade();
    }

    public void UpgradeArmor()
    {
        experience.ArmorLevellUpgrade();
    }


}
