using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


/**
 * @brief
 * klasa odpowiedzialna za reprezentację bohatera
 * 
 */
public class Hero : Creature
{
    [HideInInspector] 
    public float damageReduction = 0;
    public float armor = 1;

    //[SerializeField]
    //public Dictionary<string, AudioClip> audioClips;
    public AudioClip damageClip;
    public AudioClip[] deathClips;
    public AudioSource audioSource;

    protected Ray ray;


    // Update is called once per frame
    void Update()
    {
        Control();
    }


    /**
     * @brief
     * metoda odpowiedzialna za sterowanie
     */
    private void Control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ray.origin.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    /**
     * @brief
     * metoda odpowiedzialna za otrzymywanie obrażeń
     */
    public override void GetDamage(float damage)
    {
        health -= damage / (armor + damageReduction);

        audioSource.PlayOneShot(damageClip);

        StartCoroutine(GetDamageAnimation());
    }

    /**
     * @brief
     * metoda odpowiedzialna za zachowanie po śmierci bohatera
     */
    protected override IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(0.5F);
        animator.SetBool("dead", false);

        audioSource.PlayOneShot(deathClips[Random.Range(0,deathClips.Length-1)]);
        MusicManager.PlayMusic("Death");

        for (int i = 0; i < 801; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.02f, transform.localScale.y - 0.02f, transform.localScale.z - 0.02f);
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds(0.0001F);//animation time
        }

        GameObject.Find("UserInterface").GetComponent<UserInterface>().DeathScreen();
    }

    /**
     * @brief
     * metoda odpowiedzialna za regenerację życia i energii
     */
    public void Regenerate()
    {
        health = healthMax;
        energy = energyMax;
    }
}
