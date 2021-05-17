using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSeeking : MonoBehaviour
{
    private Vector2 targetVelocity;
    private Pilot pilot;
    
    void Start()
    {
        pilot = GetComponentInParent<Pilot>();
    }

    void Update()
    {
        if(GoalSpawn.goalActive == true && Vector2.Distance(GoalSpawn.goalLocation, transform.position) > 1)
        {

            targetVelocity = GoalSpawn.goalLocation - new Vector2(transform.position.x, transform.position.y);
            pilot.goalVelocity = targetVelocity.normalized * 3; 
        }

        if(GoalSpawn.goalActive == false)
        {
            targetVelocity = new Vector2(0, 0);
            pilot.goalVelocity = targetVelocity;
        }
    }
}
