using UnityEngine;

public class Ally : MonoBehaviour
{
    private Transform monkey;

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
        monkey = GameObject.FindGameObjectWithTag("Monkey").transform;

        fireRate = Random.Range(fireRateMin, fireRateMax);
    }

    void Update()
    {
        float distanceToMonkey = Vector3.Distance(transform.position, monkey.position);
        
        // If player is inside the radius, shoot
        if (distanceToMonkey <= checkRadius)
        {
            // Look at monkey
            Vector3 look = monkey.position;
            look.y = transform.position.y;

            transform.LookAt(look);

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