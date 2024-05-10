using System.Collections;
using System.Collections.Generic; // This line imports the System.Collections.Generic namespace, which provides functionality for working with generic collections like List.

using UnityEngine;

public class WaypointController : MonoBehaviour // This line declares a public class called WaypointController that inherits from MonoBehaviour. MonoBehaviour is a base class for most Unity scripts as it provides access to Unity's functionality.

{
    public List<Transform> waypoints = new List<Transform>(); // This line declares a public variable called waypoints that is a List of Transforms. This list will store the waypoints that the game object will follow.

    private Transform targetWaypoint; // This line declares a private variable called targetWaypoint that is a Transform. This variable will store the current waypoint that the game object is moving towards.

    private int targetWaypointIndex = 0; // This line declares a private variable called targetWaypointIndex that is an integer. This variable will store the index of the current target waypoint in the waypoints list.

    private float minDistance = 8.1f; // This line declares a private variable called minDistance that is a float. This variable will store the minimum distance that the game object needs to be from a waypoint before it moves on to the next one.

    private int lastWaypointIndex; // This line declares a private variable called lastWaypointIndex that is an integer. This variable is not currently used in the code that you provided.

    private float movementSpeed = 3.0f; // This line declares a private variable called movementSpeed that is a float. This variable will store the speed at which the game object will move between waypoints.

    // Use this for initialization
    void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex]; // This line sets the targetWaypoint variable to the first waypoint in the waypoints list.
    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime; // This line calculates the amount of movement that the game object should make in this frame based on the movementSpeed and the deltaTime (the time between the last frame and this frame).

        float distance = Vector3.Distance(transform.position, targetWaypoint.position); // This line calculates the distance between the game object's current position and the target waypoint.

        CheckDistanceToWaypoint(distance); // This line calls the CheckDistanceToWaypoint function, passing in the distance that was calculated.

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep); // This line moves the game object towards the target waypoint by the movementStep amount.
    }

    void CheckDistanceToWaypoint(float currentDistance) // This function checks if the game object is close enough to the target waypoint.
    {
        if (currentDistance <= minDistance) // This if statement checks if the current distance is less than or equal to the minDistance.
        {
            targetWaypointIndex++; // If the game object is close enough, it increments the targetWaypointIndex to move to the next waypoint in the list.

            UpdateTargetWaypoint(); // This line calls the UpdateTargetWaypoint function, which is not defined in the code that you provided.
        }
    }
    void UpdateTargetWaypoint()
    {

    }
}
