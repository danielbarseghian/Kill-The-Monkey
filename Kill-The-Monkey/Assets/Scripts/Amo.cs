using UnityEngine;

public class Amo : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;
    public float destroyRate = 5f;
    public int damage;
    private Transform player;
    [HideInInspector] public Vector3 orientation;
    [HideInInspector] public bool isParried = false;
    public string lookAtObject = "Player";


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
        // For the enemy
        if (other.CompareTag("Enemy") && isParried)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Player"))
        {
            // Get the Script
            PlayerController pc = other.GetComponentInParent<PlayerController>();

            if (pc == null)
                Debug.Log("Script Not found");

            // Initiate the function to remove a heart
            pc.RemoveHeart();
        }
    }
}
