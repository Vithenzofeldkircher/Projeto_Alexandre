using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        // Encontra o GameManager na cena
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            gameManager.ShowDefeat();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            gameManager.ShowVictory();
        }

        // Em vez de Destroy imediato, podemos apenas desativar para evitar erros de referência
        gameObject.SetActive(false);
    }
}