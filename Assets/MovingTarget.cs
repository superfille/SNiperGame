using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 1;
    public Vector3 target = Vector3.zero;
    public Vector3 player

    private Vector3 currentTarget = Vector3.zero;
    private Vector3 startingPosition = Vector3.zero;
    private string direction = "towardsTarget";
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        currentTarget = target;

        if (Vector3.Distance(transform.position, target) <= 0.001f)
        {
            currentTarget = startingPosition;
            direction = "towardsStartingPosition";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "towardsTarget")
        {
            if (Vector3.Distance(transform.position, target) <= 0.001f)
            {
                currentTarget = startingPosition;
                direction = "towardsStartingPosition";
            }
        } else
        {
            if (Vector3.Distance(transform.position, startingPosition) <= 0.001f)
            {
                currentTarget = target;
                direction = "towardsTarget";
            }
        }

        //transform.LookAt();

        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
    }
}
