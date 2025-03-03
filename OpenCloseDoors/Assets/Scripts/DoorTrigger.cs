using UnityEngine;
using UnityEngine.AI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door Door;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openSound;

    private int AgentsInRange = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            AgentsInRange++;
            if (!Door.IsOpen)
            {
                Door.Open(other.transform.position);
                PlaySound(openSound);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            AgentsInRange--;
            if (Door.IsOpen && AgentsInRange == 0)
            {
                Door.Close();
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}