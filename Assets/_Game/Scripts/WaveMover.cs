using UnityEngine;

public class WaveMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 newPosition =
            rb.position +
            Vector3.back *
            moveSpeed *
            Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}