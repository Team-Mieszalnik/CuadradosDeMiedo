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

        //weaponsImage.sprite = pickUpWeapon.weapon.GetComponent<SpriteRenderer>().sprite;
        weaponsImage.sprite = pickUpWeapon.weapon.GetComponent<Weapon>().sprite;
        weaponsImage.SetNativeSize();


        enemiesLeft.text = LevelController.enemyCounter.ToString();
        cureCooldown.color = skills.CureReady ? Color.green : Color.gray;

        heroHealthText.text = ((int)hero.health).ToString() + " / " + ((int)hero.healthMax).ToString();
        heroEnergyText.text = ((int)hero.energy).ToString() + " / " + ((int)hero.energyMax).ToString();
        heroExpirienceText.text = "EXPERIENCE: " + Experience.points.ToString();


        HealthUpgarade.image.color = experience.healthLevel == experience.healthMaxLevel ? new Color(0.29f, 0.0f, 0.5f) : experience.CanHealthUpgrade() ? new Color(1f, 0.84f, 0f) : Color.grey;
        EnergyUpgarade.image.color = experience.energyLevel == experience.energyhMaxLevel ? new Color(0.29f, 0.0f, 0.5f) : experience.CanEnergyUpgrade() ? new Color(1f, 0.84f, 0f) : Color.grey;
        MovementUpgrade.image.color = experience.movementLevel == experience.movementMaxLevel ? new Color(0.29f, 0.0f, 0.5f) : experience.CanMovementUpgrade() ? new Color(1f, 0.84f, 0f) : Color.grey;
        CureUpgarade.image.color = experience.cureLevel == experience.cureMaxLevel ? new Color(0.29f, 0.0f, 0.5f) : experience.CanCureUpgrade() ? new Color(1f, 0.84f, 0f) : Color.grey;
        ArmorUpgarade.image.color = experience.armorLevel == experience.armorMaxLevel ? new Color(0.29f, 0.0f, 0.5f) : experience.CanArmorUpgrade() ? new Color(1f, 0.84f, 0f) : Color.grey;


        heroHealthBar.value = hero.health;
        heroEnergyBar.value = hero.energy;
        //heroExpirienceBar.value = Experience.points;


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

        if (Input.GetKeyDown(KeyCode.O)) Experience.points++;

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
