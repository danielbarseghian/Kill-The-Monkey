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

    [Header("anti softlock")]
    private Vector3 startPosition;
    public float maxYArea = -30;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        fireRate = Random.Range(fireRateMin, fireRateMax);

        startPosition = transform.position;

        rb = GetComponent<Rigidbody>();
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

        if (transform.position.y < maxYArea)
        {
            rb.linearVelocity = Vector3.zero;
            transform.position = startPosition;
        }
    }

    void OnDestroy()
    {
        // Find the script
        EnemyKilled script = GameObject.FindGameObjectWithTag("EnemyKilled").GetComponent<EnemyKilled>();
        
        if (script != null)
            script.enemyKilled++;
    }
}