using UnityEngine;
using UnityEngine.InputSystem;

public class Parry : MonoBehaviour
{
    public InputAction parryInputAction;
    private GameObject parryObject;
    public Transform orientation;
    public AudioClip parryAudio;
    public AudioSource audioSource;
    public Animator animator;

    void Update()
    {
        transform.rotation = Quaternion.Euler(orientation.eulerAngles.x, orientation.eulerAngles.y, 0);

        if (parryObject && parryInputAction.WasPressedThisFrame())
        {
            animator.SetTrigger("Parry");
            audioSource.PlayOneShot(parryAudio);
            Destroy(parryObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            parryObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet") && other.gameObject == parryObject)
        {
            parryObject = null;
        }
    }

    void OnEnable()
    {
        parryInputAction.Enable();
    }

    void OnDisable()
    {
        parryInputAction.Disable();
    }
}
