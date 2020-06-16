using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
    * @brief
    * klasa zarzadzajaca paskami poziomu uleszpszenia umiejetnosci 
*/
public class SkillLevelSlider : MonoBehaviour
{

    public Slider skillSlider;
    private Experience experience;

    public enum SkillType {HEALTH, ENERGY, ARMOR, MOVEMENT, CURE};

    public SkillType skillType;

    // Start is called before the first frame update
    void Start()
    {
        experience = GameObject.FindGameObjectWithTag("Hero").GetComponent<Experience>();

        switch(skillType)
        {
            case SkillType.HEALTH:
                skillSlider.maxValue = experience.healthMaxLevel;
                skillSlider.value = experience.healthLevel;
                break;
            case SkillType.ENERGY:
                skillSlider.maxValue = experience.energyhMaxLevel;
                skillSlider.value = experience.energyLevel;
                break;
            case SkillType.MOVEMENT:
                skillSlider.maxValue = experience.movementMaxLevel;
                skillSlider.value = experience.movementLevel;
                break;
            case SkillType.ARMOR:
                skillSlider.maxValue = experience.armorMaxLevel;
                skillSlider.value = experience.armorLevel;
                break;
            case SkillType.CURE:
                skillSlider.maxValue = experience.cureMaxLevel;
                skillSlider.value = experience.cureLevel;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (skillType)
        {
            case SkillType.HEALTH:
                skillSlider.maxValue = experience.healthMaxLevel;
                skillSlider.value = experience.healthLevel;
                break;
            case SkillType.ENERGY:
                skillSlider.maxValue = experience.energyhMaxLevel;
                skillSlider.value = experience.energyLevel;
                break;
            case SkillType.MOVEMENT:
                skillSlider.maxValue = experience.movementMaxLevel;
                skillSlider.value = experience.movementLevel;
                break;
            case SkillType.ARMOR:
                skillSlider.maxValue = experience.armorMaxLevel;
                skillSlider.value = experience.armorLevel;
                break;
            case SkillType.CURE:
                skillSlider.maxValue = experience.cureMaxLevel;
                skillSlider.value = experience.cureLevel;
                break;
        }
    }
}
