using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour, Itouchable
{
    public void Active()
    {
        // troque de cena...
        //SceneManager.LoadScene("Game_Scene"); outro metodo de fazer a mesma coisa
        SceneManager.LoadScene("Game_Scene");
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
