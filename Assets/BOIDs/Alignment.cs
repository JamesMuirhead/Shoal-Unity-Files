using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{

    public List<Rigidbody2D> nearbyBodies;
    public Vector2 targetVelocity;

    private Pilot pilot;

    private void Start()
    {
        pilot = GetComponentInParent<Pilot>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BOID")
        {
            nearbyBodies.Add(collision.attachedRigidbody);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "BOID")
        {
            nearbyBodies.Remove(collision.attachedRigidbody);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //removes destroyed BOIDS
        for (int i = nearbyBodies.Count - 1; i > -1; i--)
        {
            if (nearbyBodies[i] == null)
            {
                nearbyBodies.RemoveAt(i);
            }
        }

        if (nearbyBodies.Count != 0)
        {
            float sumX = 0;
            float sumY = 0;

            for(int i = 0; i < nearbyBodies.Count; i++)
            {
                sumX += nearbyBodies[i].velocity.x;
                sumY += nearbyBodies[i].velocity.y;
            }

            float meanX = sumX / nearbyBodies.Count;
            float meanY = sumY / nearbyBodies.Count;

            targetVelocity = new Vector2(meanX, meanY);
        }

        else
        {
            targetVelocity = new Vector2(0, 0);
        }

        if(pilot.alignmentVelocity == targetVelocity)
        {
            pilot.alignmentVelocity = new Vector2(0, 0);
        }

        else
        {
            pilot.alignmentVelocity = targetVelocity;
        }
    }
}
