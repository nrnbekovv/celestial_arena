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
        Debug.Log("HIT: " + collision.gameObject.name);
        // Если коснулись Trap Block
        if (
            collision.gameObject.CompareTag("Trap")
            && !isStunned
            
        )
        {
            Debug.Log("TRAP HIT");
            // Направление отталкивания
            Vector3 pushDirection =
                (transform.position -
                collision.transform.position).normalized;

            pushDirection.y = 0;

            // Сброс скорости
            rb.linearVelocity = Vector3.zero;

            // Отталкивание
            rb.AddForce(
                pushDirection * pushForce +
                Vector3.up * upwardForce,
                ForceMode.Impulse
            );

            // Оглушение
            StartCoroutine(StunCoroutine());
        }
    }

    IEnumerator StunCoroutine()
    {
        isStunned = true;

        // Отключаем управление
        movement.enabled = false;

        // Анимация падения
        anim.SetTrigger("Fall");

        // Лежим
        yield return new WaitForSeconds(stunDuration);

        // Поднимаемся
        anim.SetTrigger("GetUp");

        // Ждем анимацию подъема
        yield return new WaitForSeconds(1f);

        // Включаем управление обратно
        movement.enabled = true;

        isStunned = false;
    }
}