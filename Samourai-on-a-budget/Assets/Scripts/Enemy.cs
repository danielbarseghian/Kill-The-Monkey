using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [Header("Bullets")]
    public GameObject amo;
    public float fireRateMax = 3;
    public float fireRateMin = 1;
    private float fireRate;
    public Transform launchArea;
    public float checkRadius = 20;
    private float fireTimer;
    [SerializeField] private LayerMask lineOfSightMask;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        fireRate = Random.Range(fireRateMin, fireRateMax);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // If player is inside the radius, shoot
        if (distanceToPlayer <= checkRadius)
        {
            // Look at player
            Vector3 look = player.position;
            look.y = transform.position.y;

            transform.LookAt(look);

            Vector3 direction = (player.position - launchArea.position).normalized;
            float distance = Vector3.Distance(launchArea.position, player.position);

            if (Physics.Raycast(launchArea.position, direction, out RaycastHit hit, distance, lineOfSightMask))
            {
                fireTimer += Time.deltaTime;

                if (fireTimer >= fireRate) 
                {
                    // Launch projectile
                    Instantiate(amo, launchArea.position, transform.rotation);
                    fireTimer = 0f;
                }
            }
        }
    }
}