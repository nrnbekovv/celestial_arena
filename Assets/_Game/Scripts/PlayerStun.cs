using UnityEngine;
using System.Collections;

public class PlayerStun : MonoBehaviour
{
    [Header("Stun Settings")]
    public float stunDuration = 1.5f;
    public float pushForce = 10f;
    public float upwardForce = 3f;

    private bool isStunned = false;

    private Rigidbody rb;
    private Animator anim;
    private PlayerMovement movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isStunned)
            return;

        if (!IsTrap(collision))
            return;

        Debug.Log("TRAP HIT");

        Vector3 pushDirection = Vector3.zero;

        if (collision.contactCount > 0)
        {
            pushDirection = collision.contacts[0].normal;
        }
        else
        {
            pushDirection = (transform.position - collision.transform.position).normalized;
        }

        pushDirection.y = 0;
        pushDirection.Normalize();

        rb.linearVelocity = Vector3.zero;

        rb.AddForce(
            pushDirection * pushForce + Vector3.up * upwardForce,
            ForceMode.Impulse
        );

        StartCoroutine(StunCoroutine());
    }

    private bool IsTrap(Collision collision)
    {
        Transform current = collision.collider.transform;

        while (current != null)
        {
            if (current.CompareTag("Trap"))
                return true;

            current = current.parent;
        }

        return false;
    }

    IEnumerator StunCoroutine()
    {
        isStunned = true;

        if (movement != null)
            movement.enabled = false;

        if (anim != null)
            anim.SetTrigger("Fall");

        yield return new WaitForSeconds(stunDuration);

        if (anim != null)
            anim.SetTrigger("GetUp");

        yield return new WaitForSeconds(1f);

        if (movement != null)
            movement.enabled = true;

        isStunned = false;
    }
}