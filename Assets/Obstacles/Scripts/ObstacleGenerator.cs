using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] Obstacle obstacle;
    public int numberOfObjects;
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        for (int i = 1; i <= numberOfObjects; i++)
        {
            pos.x += distance;
            Instantiate(obstacle, pos, rot);
        }
    }

}
