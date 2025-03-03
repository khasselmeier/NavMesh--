using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera = null;
    [SerializeField]
    private Vector3 CameraFollowOffset = new Vector3(0, 10, -2);
    [SerializeField]
    private Transform[] waypoints; // List of waypoints in the Inspector
    private int currentWaypointIndex = 0;
    private NavMeshAgent Agent;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            Agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    private void Update()
    {
        // Check if the agent reached the waypoint
        if (Agent.remainingDistance <= Agent.stoppingDistance && !Agent.pathPending)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Loop back
        Agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private void LateUpdate()
    {
        Camera.transform.position = Agent.transform.position + CameraFollowOffset;
    }
}