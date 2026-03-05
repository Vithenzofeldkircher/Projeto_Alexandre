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
        Debug.Log(gameObject.name + " agora tem " + currentHealth + " de vida.");

        StopAllCoroutines();
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Debug.Log("Vida zerada! Tentando chamar Die().");
            Die();
        }
    }



    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Duração do flash
        spriteRenderer.color = originalColor;
    }


    private void Die()
    {
        Debug.Log("Executando Destroy em: " + gameObject.name);
        Destroy(gameObject);
    }

}