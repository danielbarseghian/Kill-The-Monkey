using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Parry : MonoBehaviour
{
    public InputAction parryInputAction;
    public Transform orientation;
    public AudioClip parryAudio;
    public AudioSource audioSource;
    public Animator animator;
    public AudioClip swingSound;

    private bool getParry = false;

    void Update()
    {
        transform.rotation = Quaternion.Euler(orientation.eulerAngles.x, orientation.eulerAngles.y, 0);

        if (parryInputAction.WasPressedThisFrame() && !getParry)
        {
            getParry = true;
            animator.SetTrigger("Parry");

            StartCoroutine(EndParry());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && getParry)
        {
            Amo script =  other.gameObject.GetComponent<Amo>();
            audioSource.PlayOneShot(parryAudio);
            script.orientation = orientation.forward.normalized;
            script.speed *= 2;
            script.isParried = true;
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

    IEnumerator EndParry()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Parry"))
            yield return null;

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Parry") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            yield return null;

        getParry = false;
    }

    // I have to put this here since the script is attached to the animation
    public void PlaySwing()
    {
        audioSource.PlayOneShot(swingSound);
    }
}
