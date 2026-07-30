using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform orientation;

    // Update is called once per frame
    void Update()
    {
        transform.position = orientation.position;
    }
}
