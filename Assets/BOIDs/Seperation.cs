using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : MonoBehaviour
{
    private Pilot pilot;
    
    // Start is called before the first frame update
    void Start()
    {
        pilot = GetComponent<Pilot>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] rays = Physics2D.RaycastAll(transform.position, transform.up, 2f);
        
        if(rays.Length > 1)
        {
            float resolution = 5f;
            float angle = 120f;
            float radius = 1f;

            float Y, X, Z, tempAngle, tempAngle2;
            float directionFlip = Mathf.Sign(Random.Range(-1, 1));
            //Debug.Log(directionFlip);
            Vector3 direction;
            Vector3 center = transform.position;

            RaycastHit2D[] dangerCheck;


            for (tempAngle = 0; tempAngle <= angle; tempAngle += angle / resolution)
            {

                Y = -Mathf.Cos(tempAngle * Mathf.Deg2Rad);

                for (tempAngle2 = 0; tempAngle2 <= 180; tempAngle2 += angle / resolution)
                {

                    X = Mathf.Cos(tempAngle2 * Mathf.Deg2Rad) * Mathf.Sqrt(1 - Mathf.Pow(Y, 2));
                    Z = Mathf.Sqrt(1 - Mathf.Pow(Y, 2) - Mathf.Pow(X, 2));

                    direction = Vector3.Normalize(new Vector3(X, Y, Z * directionFlip));
                    direction = transform.rotation * -direction;

                    //Debug.DrawRay(center, direction * (radius), Color.green, .5f);
                    dangerCheck = Physics2D.RaycastAll(center, direction, radius);

                        if(dangerCheck.Length < 2)
                    {
                        pilot.seperationVelocity = direction;
                        return;
                    }

                    direction = Vector3.Normalize(new Vector3(X, Y, -Z * directionFlip));
                    direction = transform.rotation * -direction;

                    //Debug.DrawRay(center, direction * (radius), Color.green, .5f);
                    dangerCheck = Physics2D.RaycastAll(center, direction, radius);

                    if (dangerCheck.Length < 2)
                    {
                        pilot.seperationVelocity = direction;
                        return;
                    }
                }

            }
        }

        else
        {
            pilot.seperationVelocity = new Vector2(0, 0);
        }

    }
}
