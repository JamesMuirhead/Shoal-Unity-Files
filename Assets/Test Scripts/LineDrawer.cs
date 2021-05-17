using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float resolution = 9f;
        float angle = 45f;
        float radius = 0.5f;

        float Y, X, Z, tempAngle, tempAngle2;
        Vector3 direction;
        Vector3 center = transform.position;


        for (tempAngle = 0; tempAngle <= angle; tempAngle += angle / resolution)
        {
            Y = -Mathf.Cos(tempAngle * Mathf.Deg2Rad);

            for (tempAngle2 = 0; tempAngle2 <= 180; tempAngle2 += angle / resolution)
            {
                X = Mathf.Cos(tempAngle2 * Mathf.Deg2Rad) * Mathf.Sqrt(1 - Mathf.Pow(Y, 2));
                Z = Mathf.Sqrt(1 - Mathf.Pow(Y, 2) - Mathf.Pow(X, 2));

                direction = Vector3.Normalize(new Vector3(X, Y, Z));
                Debug.DrawRay(center, direction * (radius), Color.green, 10f);

                direction = Vector3.Normalize(new Vector3(X, Y, -Z));
                Debug.DrawRay(center, direction * (radius), Color.green, 10f);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
