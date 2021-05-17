using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVector : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 dir;
    private float angle;
    
   // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dir = rb2d.velocity.normalized;
        angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg + -90f;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * 15f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * 8f);
    }
}
