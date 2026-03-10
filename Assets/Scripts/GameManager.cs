using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    // Função para Vitória
    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
    }

    // Função para Derrota
    public void ShowDefeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
    }

    // Botão de Reiniciar (Volta para a Scene 0)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Despausa antes de carregar
        SceneManager.LoadScene(0);
    }

    // Botão de Sair
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}