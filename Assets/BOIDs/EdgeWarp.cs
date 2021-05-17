using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeWarp : MonoBehaviour
{
    public float offset; 

    private float xPos;
    private float yPos;

    private float xLimit;
    private float yLimit;

    private void Start()
    {
        //convert camera bounds into float
        yLimit = Camera.main.orthographicSize;
        xLimit = yLimit * Screen.width / Screen.height;

        yLimit += offset;
        xLimit += offset;
    }

    void Update()
    {
        if (transform.position.y < -yLimit || transform.position.y > yLimit)
        {
            yPos = Mathf.Clamp(transform.position.y, yLimit, -yLimit);
            transform.position = new Vector2(transform.position.x, yPos);
        }

        if (transform.position.x < -xLimit || transform.position.x > xLimit)
        {
            xPos = Mathf.Clamp(transform.position.x, xLimit, -xLimit);
            transform.position = new Vector2(xPos, transform.position.y);
        }
    }
}
