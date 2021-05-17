using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject boid;
    public int maxBoids = 40;
    public float spawnCooldown;

    private Vector2 spawnPoint;
    private float offset = 0.25f;
    private float xLimit;
    private float yLimit;

    // Start is called before the first frame update
    void Start()
    {   
        //convert camera bounds into float
        yLimit = Camera.main.orthographicSize;
        xLimit = yLimit * Screen.width / Screen.height;

        yLimit += offset;
        xLimit += offset;

        StartCoroutine(batchSpawn());
    }

    private void Update()
    {
        if (maxBoids < transform.childCount)
        {
            Transform child = transform.GetChild(transform.childCount - 1);
            Destroy(child.gameObject);
        }
    }

    IEnumerator batchSpawn()
    {

        while (true)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    spawnPoint = new Vector2(Random.Range(-xLimit, xLimit), yLimit);
                    break;

                case 1:
                    spawnPoint = new Vector2(Random.Range(-xLimit, xLimit), -yLimit);
                    break;

                case 2:
                    spawnPoint = new Vector2(xLimit, Random.Range(-yLimit, yLimit));
                    break;

                case 3:
                    spawnPoint = new Vector2(-xLimit, Random.Range(-yLimit, yLimit));
                    break;
            }

            if (maxBoids > transform.childCount)
            {
                while (maxBoids > transform.childCount)
                {
                    Instantiate(boid, spawnPoint, Quaternion.identity, transform);
                }
            }

            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
