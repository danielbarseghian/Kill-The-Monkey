using Unity.VisualScripting;
using UnityEngine;

public class Amo : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;
    public float destroyRate = 5f;
    private Transform player;
    [HideInInspector] public Vector3 orientation;
    [HideInInspector] public bool isParried = false;

    void Start()
    {
        orientation = Vector3.forward;

        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj != null)
        {
            player = playerObj.transform;

            // deadly stare to the player (litterally stare him until he dies)
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
        if (other.CompareTag("Enemy") && isParried)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponentInParent<PlayerMovement>();

            if (pm == null)
                Debug.Log("Script Not found");

            pm.RemoveHeart();
        }
    }
}
