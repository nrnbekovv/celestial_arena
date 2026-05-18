using UnityEngine;

public class TrapBlock : MonoBehaviour
{
    [Header("Trap Settings")]
    public float stunDuration = 1.5f;
    public float knockbackForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb =
                collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Направление от блока к игроку
                Vector3 direction =
                    (collision.transform.position - transform.position)
                    .normalized;

                direction.y = 0.5f;

                // Отталкивание
                playerRb.AddForce(
                    direction * knockbackForce,
                    ForceMode.Impulse
                );
            }

            // Оглушение
            PlayerMovement player =
                collision.gameObject.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.Stun(stunDuration);
            }
        }
    }
}