using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.position;

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
