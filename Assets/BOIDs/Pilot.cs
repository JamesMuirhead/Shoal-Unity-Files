using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public Vector2 alignmentVelocity;
    public Vector2 seperationVelocity;
    public Vector2 cohesionVelocity;
    public Vector2 goalVelocity;
    
    public float speed;
    public float limit;

    private Rigidbody2D rb2d;
    private Vector2 maxVelocity;

    private float seperationPriority;
    private float alignmentPriority;
    private float cohesionPriority;
    private float goalPriority;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        maxVelocity = new Vector2(speed, speed);
    }

    // Update is called once per frame
    void Update()
    {

        limit = 0f;
        Vector2 targetVelocity = new Vector2(0f, 0f);

        //add seperation velocity to target
        seperationPriority = seperationVelocity.magnitude / speed;

        if (limit + seperationPriority < 1)
        {
            targetVelocity += seperationVelocity;
            limit += seperationPriority;
        }

        else
        {
            float remainingLimit = 1 - limit;
            seperationVelocity *= remainingLimit;
            targetVelocity += seperationVelocity;
            limit += remainingLimit;
        }

        //add goal velocity
        if (limit < 1)
        {
            goalPriority = goalVelocity.magnitude / speed;

            if (limit + goalPriority < 1)
            {
                targetVelocity += goalVelocity;
                limit += goalPriority;
            }

            else
            {
                float remainingLimit = 1 - limit;
                goalVelocity *= remainingLimit;
                targetVelocity += goalVelocity;
                limit += remainingLimit;
            }
        }

        //add alignment velocity to target
        if (limit < 1)
        {
            alignmentPriority = alignmentVelocity.magnitude / speed;

            if(limit + alignmentPriority < 1)
            {
                targetVelocity += alignmentVelocity;
                limit += alignmentPriority;
            }

            else
            {
                float remainingLimit = 1 - limit;
                alignmentVelocity *= remainingLimit;
                targetVelocity += alignmentVelocity;
                limit += remainingLimit;
            }
        }

        //add cohesion velocity to target
        if (limit < 1)
        {
            cohesionPriority = cohesionVelocity.magnitude / speed;

            if (limit + cohesionPriority < 1)
            {
                targetVelocity += cohesionVelocity;
                limit += cohesionPriority;
            }

            else
            {
                float remainingLimit = 1 - limit;
                cohesionVelocity *= remainingLimit;
                targetVelocity += cohesionVelocity;
                limit += remainingLimit;
            }
        }

        //set current velocity as target
        if (targetVelocity != new Vector2(0, 0))
        {
            rb2d.velocity = targetVelocity;
        }

        else if (rb2d.velocity.magnitude < 2f)
        {
            rb2d.AddForce(transform.up * speed);
        }

    }
}
