using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CTRL + M + O/P
public class Enemy : MonoBehaviour
{

    //Declaration
    public enum State
    {
        Patrol,
        Seek
    }

    public State currentState = State.Patrol;
    public Transform target;
    public float seekRadius;

    public Transform waypointParent;
    public float moveSpeed;
    public float stoppingDistance = 1f;

    private Transform[] waypoints;
    private int currentIndex = 1;

    void Patrol()
    {
        {
            Transform point = waypoints[currentIndex];
            float distance = Vector3.Distance(transform.position, point.position);
            if (distance < .5f)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
        }

        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }

    }

    void Seek()
    {
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
    }

        // Use this for initialization
        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            //Switch current state
            switch (currentState)
            {
                case State.Patrol:
                    Patrol();
                    break;
                case State.Seek:
                    Seek();
                    break;
                default:
                    break;
            }


            //Switch current state
            //If we are in patrol
            //Call Patrol()
            //If we are in seek
            //Call Seek()


        }
    
}