using UnityEngine;

public class Bow_Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Bow bowSystem = other.GetComponent<Player_Bow>();
            if (bowSystem != null)
            {
                bowSystem.hasBow = true;
                Debug.Log("Arco Coletado! Use o Botão Direito para atirar.");
                Destroy(gameObject); // O item some do chão
            }
        }
    }
}