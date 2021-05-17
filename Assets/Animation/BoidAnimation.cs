using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D parentRb;
    private float maxSpeed;


    void Start()
    {
        animator = GetComponent<Animator>();
        parentRb = GetComponentInParent<Rigidbody2D>();
        maxSpeed = GetComponentInParent<Pilot>().speed;

        //set animation playback start postion
        animator.SetFloat("cycleOffset", Random.Range(0.0f,1.0f));
    }

    void Update()
    {
        //calculate current velocity as a fraction of max velocity
        float speed = parentRb.velocity.magnitude / maxSpeed;

        //set animation speed multiplyier as fraction
        animator.SetFloat("speed", speed);
    }
}
