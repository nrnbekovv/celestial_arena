using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 7f;
    public float jumpForce = 11f;
    public float airControl = 0.05f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.4f;

    [Header("Audio")]
    public AudioClip jumpSound;

    private Animator anim;
    private Rigidbody rb;
    private AudioSource audioSource;

    private bool isGrounded;
    private bool wasGrounded;

    private Vector3 moveDirection;
    private bool isStunned = false;
    private int jumpCount = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        rb.collisionDetectionMode =
            CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        if (isStunned)
            return;

        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        moveDirection =
            new Vector3(moveH, 0, moveV).normalized;

        isGrounded = Physics.CheckSphere(
            transform.position,
            groundCheckRadius,
            groundLayer
        );

        if (isGrounded && !wasGrounded)
        {
            jumpCount = 0;
        }

        wasGrounded = isGrounded;

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount == 0)
            {
                PerformJump(false);
                jumpCount = 1;
            }
            else if (jumpCount == 1)
            {
                PerformJump(true);
                jumpCount = 2;
            }
        }

        anim.SetFloat(
            "Speed",
            moveDirection.magnitude
        );
    }

    void FixedUpdate()
    {
        if (isStunned)
            return;

        Vector3 movement =
            moveDirection * speed * Time.fixedDeltaTime;

        rb.MovePosition(
            rb.position + movement
        );

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                0.2f
            );
        }
    }

    void PerformJump(bool spinJump)
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            0,
            rb.linearVelocity.z
        );

        rb.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
        );

        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }

        if (spinJump)
        {
            anim.SetTrigger("JumpSpin");
        }
        else
        {
            anim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            jumpCount = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            groundCheckRadius
        );
    }

    public void Stun(float duration)
    {
        if (isStunned)
            return;

        StartCoroutine(StunCoroutine(duration));
    }

    private System.Collections.IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;

        anim.SetTrigger("Dizzy");

        yield return new WaitForSeconds(duration);

        isStunned = false;
    }
}