using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerController script = other.gameObject.transform.parent.GetComponentInParent<PlayerController>();

            if (script != null)
                script.startPosition = transform.position;
            else
                Debug.Log("Script not found :(");
        }
    }
}
