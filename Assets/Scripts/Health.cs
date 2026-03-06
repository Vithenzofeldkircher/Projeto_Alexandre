using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para o reset
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false; // Evita que Die() seja chamado mil vezes

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return; // Se já morreu, ignora novos danos

        currentHealth -= amount;
        Debug.Log(gameObject.name + " recebeu dano. Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player morreu! Resetando cena...");
            // Chama o reset após um pequeno delay de 0.5s para o player ver que morreu
            Invoke("RestartGame", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void RestartGame()
    {
        // Recarrega a cena atual do zero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}