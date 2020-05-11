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

    private Vector3 endPosition;
    private Vector2 mousePosition;
    private Vector3 auxiliaryOriginVector;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        endPosition = transform.position + (transform.right * beamLength);
        lineRenderer.SetPositions(new Vector3[] { transform.position, endPosition });


        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x > transform.position.x) 
        {
            auxiliaryOriginVector = new Vector3(1, 0, 0);
        }
        else
        {
            auxiliaryOriginVector = new Vector3(-1, 0, 0);
        }


        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + auxiliaryOriginVector, transform.right * beamLength, beamLength);

        foreach (RaycastHit2D hit in hits)
        {
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
