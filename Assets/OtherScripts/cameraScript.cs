using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public bool rotationOn;

    // Update is called once per frame
    void Update()
    {
        if (!rotationOn) transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
