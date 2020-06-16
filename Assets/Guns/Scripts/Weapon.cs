using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/**
* @brief
* klasa odpowiedzialna za ogolne dzialanie broni, kazda inna bron dziedziczy z tej klasy
*/
public abstract class Weapon : MonoBehaviour
{
    public bool isActive;
    public float attackSpeed;
    public float ammo;
    public Sprite sprite;

    public Transform firePoint;
    public GameObject bulletPrefab;

    protected Animator animator;
    protected Vector2 mousePosition;
    protected AudioSource audioSource;

    protected float time;

    protected bool isShooting;

    // Start is called before the first frame update
    protected void Start()
    {
        animator = this.GetComponent<Animator>();
        time = attackSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame]
    /**
    * @brief
    * sprawdzenie czy bron jest aktywna czy wcisniety jest przycisk odpowiedzilany za strzal dekrementowanie amunicji i wykonywanie metody odpowiadajacej za strzelanie
    */
    protected void Update()
    {
        if (!isActive) return;
        if (ammo <= 0) Destroy(gameObject);
        if (Input.GetMouseButtonDown(0)) StartShooting();
        if (isShooting) Shooting();
        if (Input.GetMouseButtonUp(0)) StopShooting();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        time += Time.deltaTime;
    }

    /**
    * @brief
    * ustawienie broni w kierunku strzalu czyli kursora myszki
    */
    protected void FixedUpdate()
    {
        if (isActive)
        {
            Vector2 lookDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            if (mousePosition.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0, angle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(180f, 0, -angle);
            }
        }
    }

    protected virtual void StartShooting() => isShooting = true;
    protected virtual void StopShooting() => isShooting = false;

    /**
    * @brief
    * metoda wywolywana w trakcie strzelania bronia
    */
    protected virtual void Shooting()
    {
        if (time > attackSpeed)
        {
            audioSource.Play();
            time = 0;
            ammo--;
            StartCoroutine(ShootAnimation());
            Shoot();
        }
    }


    protected virtual void Shoot() { }

    /**
    * @brief
    * metoda wywolywana w  do animacji strzalu
    */
    protected virtual IEnumerator ShootAnimation()
    {
        animator.SetBool("shoot", true);

        yield return new WaitForSeconds(attackSpeed - 0.04f);

        animator.SetBool("shoot", false);
    }
}
