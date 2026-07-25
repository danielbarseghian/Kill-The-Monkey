using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [Header("Bullets")]
    public GameObject amo;
    public float fireRate = 1;
    public Transform launchArea;
    public float checkRadius = 20;
    private float fireTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        
            // Launch projectile
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate) {
                Instantiate(amo, launchArea.position, transform.rotation);
                fireTimer = 0f;
            }
        }
    }
}