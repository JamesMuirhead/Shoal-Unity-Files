using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    public static bool goalActive = false;
    public static Vector2 goalLocation = new Vector2(0, 0);
    public GameObject goal;
    public Camera mainCamera;
    private Vector3 mousePos;
    private Vector3 goalPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            goalActive = false;
        }

        if (Input.GetMouseButton(0) && transform.childCount == 0 && ParamUI.paramOpen == false)
        {
            mousePos = Input.mousePosition;

            goalPos = mainCamera.ScreenToWorldPoint(mousePos);
            goalPos.z = 0f;

            goalLocation = goalPos;
            goalActive = true;
        }

        if(Input.GetMouseButtonUp(0) && transform.childCount == 0 && ParamUI.paramOpen == false)
        {
            GameObject newGoal = Instantiate(goal, goalPos, Quaternion.identity, transform);
            Destroy(newGoal, 5f);

            goalLocation = goalPos;
            goalActive = true;
        }

    }
}
