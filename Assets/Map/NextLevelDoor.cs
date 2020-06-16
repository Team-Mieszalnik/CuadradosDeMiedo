using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

/**
    * @brief
    * Klasa do obslugi przejscia do nastepnego poziomu
    */
public class NextLevelDoor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider2D;
    Light2D light2;

    bool nextAnimation;

    float x, y, z = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        light2 = GetComponent<Light2D>();

        spriteRenderer.enabled = false;
        circleCollider2D.enabled = false;
        light2.enabled = false;

        nextAnimation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.enemyCounter <= 0) 
        {
            spriteRenderer.enabled = true;
            circleCollider2D.enabled = true;
            light2.enabled = true;
        }


        if (nextAnimation == true) 
        {
            //StartCoroutine(DoorAnimation());
            DoorAnimation();
        }
    }

    /**
        * @brief
        * metoda animujaca drzwi
        */
    private void DoorAnimation()
    {
        nextAnimation = false;

        //yield return new WaitForSeconds(0.001f);

        transform.rotation = Quaternion.Euler(x, y, z);

        x += 0.9f;
        y += 0.5f;
        z += 0.8f;

        nextAnimation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero target = collision.GetComponent<Hero>();

        if (target != null)
        {
            target.Regenerate();

            MapController.EndLevel();
        }
    }
}
