using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycircle : MonoBehaviour
{
    public float angle = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(castRays());
    }

    IEnumerator castRays()
    {
        Transform target;
        Quaternion offset = new Quaternion(0f, 0f, 0f, 0f);
        

        while (true)
        {

            target = gameObject.transform;
            target.rotation = new Quaternion(0f, 0f, angle, 0f);

            Debug.DrawRay(transform.position, target.up, Color.green, 1f);

            angle += 0.01f;

            yield return new WaitForSeconds(0.5f);
        }


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
