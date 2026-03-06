using UnityEngine;

public class Homing_Arrow : MonoBehaviour
{
    [Header("Confuguração")]

    public float speed = 12f;
    public float damage = 1f;
    public float rotateSpeed = 200f; // Velocidade da curva
    public float lifeTime = 5f;

    private Transform target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    public void SetTarget(Transform newTarget) => target = newTarget;

    void FixedUpdate()
    {
        if (target != null)
        {
            // Lógica de perseguição (Homing)
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.linearVelocity = transform.right * speed;
        }
        else
        {
            // Se não há alvo, voa reto
            rb.linearVelocity = transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null && !collision.CompareTag("Player"))
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}