using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : MonoBehaviour
{
    public float targetSeperation;
    public List<GameObject> nearbyBodies;
    private Pilot pilot;
    private Vector2 targetPostion;
    private Vector2 targetVelocity;


    private void Start()
    {
        pilot = GetComponentInParent<Pilot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BOID")
        {
            nearbyBodies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BOID")
        {
            nearbyBodies.Remove(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //removes destroyed BOIDS
        for (int i = nearbyBodies.Count - 1; i > -1; i--)
        {
            if(nearbyBodies[i] == null)
            {
                nearbyBodies.RemoveAt(i);
            }
        }

        if (nearbyBodies.Count > 1)
        {
            float sumX = 0;
            float sumY = 0;

            for (int i = 0; i < nearbyBodies.Count; i++)
            {
                    //objects too close dont get included, leads to natural seperation
                    if (Vector2.Distance(transform.position, nearbyBodies[i].transform.position) > targetSeperation)
                    {
                        sumX += nearbyBodies[i].transform.position.x;
                        sumY += nearbyBodies[i].transform.position.y;
                    }
            }

            float meanX = sumX / nearbyBodies.Count;
            float meanY = sumY / nearbyBodies.Count;

            targetPostion = new Vector2(meanX, meanY);

            targetVelocity = targetPostion - new Vector2(transform.position.x, transform.position.y);
        }

        else
        {
            targetVelocity = new Vector2(0, 0);
        }

        pilot.cohesionVelocity = targetVelocity.normalized * 3;
    }
}
