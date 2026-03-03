using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 3f;
    public float checkRadius = 5f;      // Distância que ele começa a seguir
    public float attackRadius = 1f;     // Distância que ele para para atacar

    [Header("Ataque")]
    public float damage = 10f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    public LayerMask whatIsPlayer;
    private Transform player;

    void Start()
    {
        // Procura o jogador pela Tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Logica de Perseguição
        if (distanceToPlayer <= checkRadius && distanceToPlayer > attackRadius)
        {
            FollowPlayer();
        }
        // Logica de Ataque
        else if (distanceToPlayer <= attackRadius)
        {
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    void FollowPlayer()
    {
        // Move o inimigo em direção ao player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }

    void AttackPlayer()
    {
        Debug.Log("Inimigo atacou o Player!");
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    // Visualização no Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}