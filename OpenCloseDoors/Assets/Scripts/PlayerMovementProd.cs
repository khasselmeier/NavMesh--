using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementProd : MonoBehaviour
{
    [SerializeField]
    private Camera Camera = null;
    [SerializeField]
    private Vector3 CameraFollowOffset = new Vector3(0, 10, -2);
    [SerializeField]
    private LayerMask LayerMask;
    [SerializeField]
    private float KeyRotationSpeed = 50.0f;

    private NavMeshAgent Agent;
    private float rotationX = 0f;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask))
            {
                Agent.SetDestination(hit.point);
            }
        }

        HandleKeyRotation();
    }

    private void LateUpdate()
    {
        Camera.transform.position = Agent.transform.position + CameraFollowOffset;
        Camera.transform.rotation = Quaternion.Euler(0, rotationX, 0);
    }

    private void HandleKeyRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotationX -= KeyRotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationX += KeyRotationSpeed * Time.deltaTime;
        }
    }
}
