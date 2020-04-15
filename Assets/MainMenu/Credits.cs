using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public float speed;
    public Transform rect;
    public GameObject fin;

    private float time;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 3)
        {
            fin.SetActive(false);
            rect.position = new Vector3(rect.position.x, rect.position.y + speed, rect.position.z);
        }


        if (rect.position.y > Screen.height + 2000)
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

}
