using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform orientation;

    // Update is called once per frame
    void Update()
    {
        transform.position = orientation.position;

        transform.rotation = Quaternion.Euler(0, orientation.eulerAngles.y, 0);
    }
}
