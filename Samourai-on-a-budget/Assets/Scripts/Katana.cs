using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Katana : MonoBehaviour
{
    public InputAction slayAction;
    public Transform orientation;
    public Animator animator;
    private bool isAttacking = false;
    void Start()
    {
        slayAction.Enable();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(orientation.eulerAngles.x, orientation.eulerAngles.y, 0);

        if (slayAction.WasPressedThisFrame() && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Swing");

            StartCoroutine(EndSwing());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && isAttacking)
        {
            Destroy(other.gameObject);
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

    IEnumerator EndSwing()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
            yield return null;

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Swing") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            yield return null;

        isAttacking = false;
    }
}
