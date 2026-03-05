using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Estado")]
    public bool hasSword = false; // O player começa sem a espada

    [Header("Configurações de Ataque")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float damage = 25f;
    public LayerMask enemyLayers;

    [Header("Timing")]
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        // Se não tiver a espada, o código para aqui e não executa o ataque
        if (!hasSword) return;

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                Debug.Log("Deu dano");
            }
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}