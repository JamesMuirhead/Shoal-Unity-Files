using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehaviour : MonoBehaviour
{
    public float boredom;
    public float speed;
    private GameObject boids;
    public List<Transform> prey;
    private Rigidbody2D rb2d;
    private Vector2 targetVelocity;
    private bool hungry = true;
    private float yLimit;
    private float xLimit;
    private float offset = 3f;
    private int target;
    
    // Start is called before the first frame update
    void Start()
    {
        //convert camera bounds into float
        yLimit = Camera.main.orthographicSize;
        xLimit = yLimit * Screen.width / Screen.height;

        yLimit += offset;
        xLimit += offset;

        rb2d = GetComponent<Rigidbody2D>();
        boids = GameObject.Find("BOID Spawner");

        target = Random.Range(0, prey.Count - 1);

        foreach (Transform child in boids.transform)
        {
            if(child != null)
            {
                prey.Add(child);
            }
        }

        StartCoroutine(boredomCounter());
    }

    // Update is called once per frame
    void Update()
    {

        if (prey.Count != 0 && hungry == true)
        {
            if (prey[target] == null)
            {
                target = Random.Range(0, prey.Count - 1);
            }

            targetVelocity = prey[target].position - transform.position;
        }

        if (hungry == false)
        {
            if(transform.position.y > yLimit || transform.position.y < -yLimit || transform.position.x > xLimit || transform.position.x < -xLimit)
            {
                Destroy(gameObject);
            }
        }

        rb2d.velocity = targetVelocity.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BOID")
        {
            hungry = false;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator boredomCounter()
    {
        yield return new WaitForSeconds(boredom);
        hungry = false;
    }
}
