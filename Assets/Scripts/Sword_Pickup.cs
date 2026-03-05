using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Esse comando vai escrever no seu Console toda vez que algo encostar na espada
        Debug.Log("Algo encostou na espada: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerAttack playerAtk = other.GetComponent<PlayerAttack>();

            if (playerAtk != null)
            {
                playerAtk.hasSword = true;
                Debug.Log("SUCESSO: Espada coletada!");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("ERRO: Encontrei o Player, mas ele não tem o script PlayerAttack!");
            }
        }
    }
}