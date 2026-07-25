using UnityEngine;

public class Amo : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;
    public float destroyRate = 5f;
    private Transform player;

    void Start()
    {
        // Find the player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj != null)
        {
            player = playerObj.transform;
            // Face the player instantly upon spawning
            transform.LookAt(player);
        }
    }

    void Update()
    {
        // Vector3.forward moves the bullet in its OWN forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Timer to destroy bullet
        timer += Time.deltaTime;
        if (timer >= destroyRate)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // boom boom
        }
    }
}
