using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool isActive;
    public float attackSpeed;

    public Transform firePoint;
    public GameObject bulletPrefab;

    protected Animator animator;
    protected Vector2 mousePosition;

    protected float time;

    // Start is called before the first frame update
    protected void Start()
    {
        animator = this.GetComponent<Animator>();
        time = attackSpeed;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (isActive)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Control();

            time += Time.deltaTime;
        }
    }

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

    protected virtual void Control()
    {
        if (Input.GetMouseButton(0) && time > attackSpeed)
        {
            time = 0;
            Shoot();
            StartCoroutine(ShootAnimation());
        }
    }

    protected virtual void Shoot()
    {

    }


    protected virtual IEnumerator ShootAnimation()
    {
        animator.SetBool("shoot", true);

        yield return new WaitForSeconds(attackSpeed - 0.09f);

        animator.SetBool("shoot", false);
    }
}
