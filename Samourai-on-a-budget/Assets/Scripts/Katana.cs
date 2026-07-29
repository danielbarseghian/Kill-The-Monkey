using UnityEngine;
using UnityEngine.InputSystem;

public class Katana : MonoBehaviour
{
    public InputAction slayAction;
    public Transform orientation;
    public Animator animator;
    
    // Tracks the current enemy inside our weapon's trigger zone
    private GameObject killObject;

    void Start()
    {
        slayAction.Enable();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(orientation.eulerAngles.x, orientation.eulerAngles.y, 0);

        if (slayAction.WasPressedThisFrame())
        {
            animator.SetTrigger("Swing");

            // Check if an enemy is in range AND the player just pressed the button
            if (killObject)
            {
                Destroy(killObject);
                killObject = null; // Clear the reference since the object is gone
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            killObject = other.gameObject;
        }
    }

    // CRUCIAL: Forget the enemy if we walk away from it without attacking
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject == killObject)
        {
            killObject = null;
        }
    }

    void OnEnable()
    {
        slayAction.Enable();
    }

    void OnDisable()
    {
        slayAction.Disable();
    }
}
