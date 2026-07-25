using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public float jumpMultiplier = 1.25f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.up * (rb.linearVelocity.magnitude * jumpMultiplier), ForceMode.Impulse);
        }
    }
}
