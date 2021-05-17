using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorSpawner : MonoBehaviour
{
    public GameObject predator;
    public float spawnCooldown;
    public int maxPredators;

    private Vector2 spawnPoint;
    private float offset = 3f;
    private float xLimit;
    private float yLimit;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        //convert camera bounds into float
        yLimit = Camera.main.orthographicSize;
        xLimit = yLimit * Screen.width / Screen.height;

        yLimit += offset;
        xLimit += offset;

        //StartCoroutine(spawnMover());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= maxPredators && spawning == false)
        {
            spawning = true;
            StartCoroutine(spawnPredator());
        }
    }

    IEnumerator spawnPredator()
    {
        yield return new WaitForSeconds(spawnCooldown);

        while (transform.childCount < maxPredators)
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

            Instantiate(predator, spawnPoint, Quaternion.identity, transform);
            yield return new WaitForSeconds(.25f);
        }

        spawning = false;
    }

    IEnumerator spawnMover()
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

            yield return new WaitForSeconds(10);
        }
    }
}
