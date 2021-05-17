using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVeiwer : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 2f, Color.green);
    }
}
