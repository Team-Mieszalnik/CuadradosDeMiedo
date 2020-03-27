using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float beamLength;
    public float Damage;
    public float Cooldown;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPosition = transform.position + (transform.right * beamLength);
        lineRenderer.SetPositions(new Vector3[] { transform.position, endPosition });



        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * beamLength);

        if (hit)
        {
            //time = 0;
            var target = hit.transform.GetComponent<IGetDamaged>();
            if (target != null)
            {
                if (time > Cooldown)
                {
                    target.GetDamage(Damage);
                    time = 0;
                }
                time += Time.deltaTime;
            }
        }
    }
}
