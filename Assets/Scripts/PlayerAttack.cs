using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurações de Ataque")]
    public Transform attackPoint; // Um objeto vazio na frente do player
    public float attackRange = 0.5f;

    public float damage = 25f;
    public LayerMask enemyLayers; // Definir a Layer dos inimigos na Unity

    [Header("Timing")]
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        // Ataca ao pressionar o botão esquerdo do mouse (ou Espaço)
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Detectar inimigos no alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Causar dano em cada inimigo detectado
        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    // Desenha o círculo de ataque no Editor isso facilita na hora de ajustar lá
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}