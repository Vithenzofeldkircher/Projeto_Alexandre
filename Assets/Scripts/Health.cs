using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Feedback Visual (Game Juice)
        StopAllCoroutines(); // Para o piscar caso ele tome dano seguido
        StartCoroutine(FlashRed());

        if (currentHealth <= 0) Die();
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Duração do flash
        spriteRenderer.color = originalColor;
    }

    private void Die()
    {
        // Aqui você pode instanciar partículas de sangue antes de destruir
        Destroy(gameObject);
        Debug.Log("Morreu");
    }
}