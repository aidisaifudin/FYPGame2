using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // list of waypoints
    private Transform targetWaypoint; //initial start of waypoint
    private int targetWaypointIndex = 0; //index in the waypoint list
    private float minDistance = 0.1f; //distance to know when he is reaching the waypoint
    private int lastWaypointIndex;

    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; //start with the first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;

        float dist = directionToTarget.sqrMagnitude;
        directionToTarget.y = 0;


        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); //smooth rotation
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        //float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        //Debug.Log("Distance: " + distance);
        

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep); // move towards first waypoint
        CheckDistanceToWaypoint(dist);

    }

    void CheckDistanceToWaypoint(float currentDistance) //check if target is near a waypoint
    {
        if(currentDistance <= minDistance)
        {
            //targetWaypointIndex++; //if target near a waypoint, go to next waypoint index
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if(targetWaypointIndex > lastWaypointIndex) //to check if hit last waypoint, it will go back to the first
        {
            targetWaypointIndex = 0;
        }

        int randomWaypoint = ReturnRandomWaypoint(targetWaypointIndex);
        targetWaypoint = waypoints[randomWaypoint]; // new waypoint after targetwaypointIndex + 1 
    }

    private int ReturnRandomWaypoint(int currentWaypoint)
    {
        int randomWaypoint = UnityEngine.Random.Range(0, waypoints.Count); //Get a random waypoint index from the list of waypoints
        if (currentWaypoint == randomWaypoint) //If the random index is the same as the current waypoint, just call the fubnction again to get a new one
        {
            ReturnRandomWaypoint(currentWaypoint);
        }

        currentWaypoint = randomWaypoint;
        return randomWaypoint;
    }
}
