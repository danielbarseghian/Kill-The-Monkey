using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement script = other.gameObject.GetComponent<PlayerMovement>();

            script.startPosition = transform.position;
        }
    }
}
