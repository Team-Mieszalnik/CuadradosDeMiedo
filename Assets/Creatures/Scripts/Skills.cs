using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
         * @brief
         * Klasa do zarzadzania umiejetnosciami bohatera 
         */
public class Skills : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip healClip;
    public AudioClip shieldClip;

    private bool SkillsReady = true;
    [HideInInspector]
    public bool CureReady = true;

    public float curePower = 20;
    public float cureEnergy = 40;
    public float cureDelay = 5;

    public float sprintPower = 5;
    public float sprintEnergy = 10;

    public float defensePower = 1;
    public float defenseEnergy = 5;


    private Rigidbody2D rb;
    private Animator animator;
    private Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }


    /**
         * @brief
         * Metoda do sterowania umiejetnosciami 
         */
    private void Control()
    {
        if (Input.GetKey(KeyCode.LeftShift) && SkillsReady) 
        {
            StartCoroutine(SprintSkill());
        }
        if (Input.GetKey(KeyCode.Space) && SkillsReady) 
        {
            StartCoroutine(DefenseSkill());
        }
        if (Input.GetKey(KeyCode.Q) && CureReady) 
        {
            StartCoroutine(CureSkill());
        }
    }


    /**
         * @brief
         * Metoda do obslugi umiejetnosci sprintu 
         */
    private IEnumerator SprintSkill()
    {
        if (hero.energy > sprintEnergy)
        {
            SkillsReady = false;
            animator.SetBool("useSprint", true);
            hero.energy -= sprintEnergy;
            hero.speed += sprintPower;

            yield return new WaitForSeconds(1);//animation time and skill time

            hero.speed -= sprintPower;
            animator.SetBool("useSprint", false);
            SkillsReady = true;
        }
    }

    /**
     * @brief
     * Metoda do obslugi umiejetnosci obrony 
     */
    private IEnumerator DefenseSkill()
    {
        if (hero.energy > defenseEnergy)
        {
            SkillsReady = false;
            animator.SetBool("useDefense", true);
            hero.energy -= defenseEnergy;
            hero.damageReduction *= defensePower;


            audioSource.PlayOneShot(shieldClip);

            yield return new WaitForSeconds(1);//animation time and skill time

            hero.damageReduction /= defensePower;
            animator.SetBool("useDefense", false);
            SkillsReady = true;
        }
    }

    /**
        * @brief
        * Metoda do obslugi umiejetnosci leczenia 
        */
    private IEnumerator CureSkill()
    {
        if (hero.energy > cureEnergy)
        {
            SkillsReady = false;
            CureReady = false;

            animator.SetBool("useCure", true);
            hero.energy -= cureEnergy;
            if (hero.health + curePower > hero.healthMax)
            {
                hero.health = hero.healthMax;
            }
            else
            {
                hero.health += curePower;
            }


            audioSource.PlayOneShot(healClip);

            yield return new WaitForSeconds(1);//animation time;

            animator.SetBool("useCure", false);
            SkillsReady = true;

            yield return new WaitForSeconds(cureDelay - 1);//cureDelay - animation time

            CureReady = true;
        }
    }
}
