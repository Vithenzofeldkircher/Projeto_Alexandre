using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} recebeu dano! Vida atual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} morreu!");
        // Aqui você pode adicionar animação de morte ou destruir o objeto
        Destroy(gameObject);
    }
}