using System.Collections;
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
    private bool getParry = false;

    void Update()
    {
        Debug.Log($"{getParry}");
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
            audioSource.PlayOneShot(parryAudio);
            Destroy(parryObject);
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
        // Wait until the transition into Parry actually completes
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Parry"))
            yield return null;

        // Now wait until it finishes playing
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Parry") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            yield return null;

        getParry = false;
    }
}
