using UnityEngine;

public class AllyAmo : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;
    public float destroyRate = 5f;
    public int damage = 10;
    private Transform player;
    [HideInInspector] public Vector3 orientation;
    public string lookAtObject = "Monkey";


    void Start()
    {
        orientation = Vector3.forward;

        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag(lookAtObject);
        
        if (playerObj != null)
        {
            // Oriente ourself to the Player
            player = playerObj.transform;

            transform.LookAt(player);
            orientation = transform.forward;
        }
    }

    void Update()
    {
        transform.position += orientation * speed * Time.deltaTime;

        // Timer to destroy bullet
        timer += Time.deltaTime;
        if (timer >= destroyRate)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"entered trigger {other.gameObject.name}");

        // For the enemy
        if (other.CompareTag("Monkey"))
        {
            // Get the script
            Monkey script = other.GetComponent<Monkey>();

            // Remove health
            script.health -= damage;

            // End my destroing the object to optimize
            Destroy(gameObject);
        }
    }
}
